
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;




namespace Xtreme
{
	internal partial class frmSysMigrate
		: System.Windows.Forms.Form
	{

		public frmSysMigrate()
{
InitializeComponent();
} 
 public  void frmSysMigrate_old()
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


		private void frmSysMigrate_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//************************************************************************'
		//                           Data Migration Wizard
		//
		//Date  : 11-Dec-2007
		//Coder: Moiz Hakimiuddin Ghee Wala
		//*************************************************************************
		
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
		private XArrayHelper _TableArray = null;
		private XArrayHelper TableArray
		{
			get
			{
				if (_TableArray is null)
				{
					_TableArray = new XArrayHelper();
				}
				return _TableArray;
			}
			set
			{
				_TableArray = value;
			}
		}

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


		//Constants for Sys_Migrate_Table
		private const int Table_Id = 0;
		private const int LTableName = 1;
		private const int ATableName = 2;
		private const int TableComments = 3;
		private const int TableName = 4;

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
		private const int FieldComments = 3;
		private const int AllowDuplicate = 4;
		private const int AllowNull = 5;
		private const int Lenth = 6;
		private const int DataType = 7;

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
				mHourGlass = null;
			}
			catch (System.Exception excep)
			{
				mHourGlass = null;
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cmbMigrateScheme_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			LoadGrdCombo(cmbMigrateScheme.SelectedIndex);
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

				txtTip.Text = "Migrating Data.....";
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




				MessageBox.Show("Data migrated successfully.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			object i = null;
			try
			{
				this.Width = 766;
				this.Height = 507;
				this.Left = 0;
				this.Top = 0;
				DataSet rs = new DataSet();
				//UPGRADE_ISSUE: (2064) VSFlex8L.ControlFlagsSettings property ControlFlagsSettings.flexCFAutoClipboard was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) VSFlex8.VSFlexGrid property grdMigrate2.flags was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdMigrate2.setFlags(UpgradeStubs.VSFlex8L_ControlFlagsSettings.getflexCFAutoClipboard());
				txtTip.Text = "";
				SqlDataAdapter adap = new SqlDataAdapter("select smt.* from sm_migration_table smt left outer join SM_MODULES sm on smt.module_id = sm.module_id where sm.show=1 and smt.show = 1", SystemVariables.gConn);
				rs.Tables.Clear();
				adap.Fill(rs);
				TableArray.RedimXArray(new int[]{rs.Tables[0].Rows.Count, 4}, new int[]{1, 0});
				i = 1;
				cmbMigrateScheme.Items.Clear();
				foreach (DataRow iteration_row in rs.Tables[0].Rows)
				{
					TableArray.SetValue(iteration_row["Table_Id"], ReflectionHelper.GetPrimitiveValue<int>(i), 0);
					TableArray.SetValue(iteration_row["L_Table_Name"], ReflectionHelper.GetPrimitiveValue<int>(i), 1);
					TableArray.SetValue(iteration_row["A_Table_Name"], ReflectionHelper.GetPrimitiveValue<int>(i), 2);
					TableArray.SetValue(iteration_row["Comments"], ReflectionHelper.GetPrimitiveValue<int>(i), 3);
					TableArray.SetValue(iteration_row["Table_Name"], ReflectionHelper.GetPrimitiveValue<int>(i), 4);
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						cmbMigrateScheme.AddItem(Convert.ToString(iteration_row["L_Table_Name"]), Convert.ToInt32(ReflectionHelper.GetPrimitiveValue<double>(i) - 1));
					}
					else
					{
						cmbMigrateScheme.AddItem(Convert.ToString(iteration_row["A_Table_Name"]), Convert.ToInt32(ReflectionHelper.GetPrimitiveValue<double>(i) - 1));
					}
					i = ReflectionHelper.GetPrimitiveValue<double>(i) + 1;
				}

				this.WindowState = FormWindowState.Maximized;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				frameMain.Left = 0;
				frameMain.Top = 0;
				frameMain.Height = Convert.ToInt32(Support.ToPixelsUserHeight(this.Height * 15, 7966.6, 530));
				frameMain.Width = Convert.ToInt32(Support.ToPixelsUserWidth(this.Width * 15, 11010, 734));
				grdMigrate1.Width = (Convert.ToInt32(Support.FromPixelsUserWidth(frameMain.Width, 11010, 734)) - 350) / 15;
				grdMigrate2.Width = (Convert.ToInt32(Support.FromPixelsUserWidth(frameMain.Width, 11010, 734)) - 350) / 15;
				grdMigrate2.Height = Convert.ToInt32(Support.FromPixelsUserHeight(frameMain.Height, 7950, 530)) / 15 - txtTip.Height - grdMigrate2.Top - 13;
				txtTip.Width = (Convert.ToInt32(Support.FromPixelsUserWidth(frameMain.Width, 11010, 734)) - 100) / 15;
				txtTip.Top = grdMigrate2.Top + grdMigrate2.Height + 3;
				//UPGRADE_ISSUE: (2064) Line property Line1.X2 was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				Line1.setX2(Convert.ToInt32(Support.FromPixelsUserWidth(frameMain.Width, 11010, 734)));
				//UPGRADE_ISSUE: (2064) Line property Line2.X2 was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				Line2.setX2(Convert.ToInt32(Support.FromPixelsUserWidth(frameMain.Width, 11010, 734)));
				Shape1.Height = grdMigrate1.Height + grdMigrate2.Height + (grdMigrate2.Top - (grdMigrate1.Top + grdMigrate1.Height)) + 7;
				Shape1.Width = grdMigrate1.Width + grdMigrate2.Width + (grdMigrate2.Left - (grdMigrate1.Left + grdMigrate1.Width)) + 9;
				FrameCmb.Left = (Convert.ToInt32(Support.FromPixelsUserWidth(frameMain.Width, 11010, 734)) / 15 - FrameCmb.Width) - 7;
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

		private object ResembleGrid()
		{
			grdMigrate1.Cols.Fixed = 1;
			grdMigrate1.Rows.Fixed = 0;
			grdMigrate1.Cols.Count = grdMigrate2.Cols.Count;
			grdMigrate1.Rows.Count = 1;
			return null;
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

		private object LoadGrdCombo(int pType)
		{
			int i = 0;
			DataSet rs = new DataSet();
			string mysql = "";
			txtTip.Text = Convert.ToString(TableArray.GetValue(pType + 1, 3)) + "";
			grdMigrate1.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			grdMigrate1.AllowEditing = true;
			grdMigrate1.Cols[grdMigrate1.Col].ComboList = "";
			grdMigrate1.Cols[grdMigrate1.Col].ComboList = "(None)" + "|";
			mysql = "select * from sm_migration_table_fields where table_id = " + Convert.ToString(TableArray.GetValue(pType + 1, 0)) + " and show = 1 ";
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rs.Tables.Clear();
			adap.Fill(rs);
			FieldArray.RedimXArray(new int[]{rs.Tables[0].Rows.Count, 7}, new int[]{1, 0});
			int tempForEndVar = rs.Tables[0].Rows.Count - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				FieldArray.SetValue(rs.Tables[0].Rows[0]["L_Field_Name"], i + 1, 0);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				FieldArray.SetValue(rs.Tables[0].Rows[0]["A_Field_Name"], i + 1, 1);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				FieldArray.SetValue(rs.Tables[0].Rows[0]["Field_Name"], i + 1, 2);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				FieldArray.SetValue(rs.Tables[0].Rows[0]["Comments"], i + 1, 3);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				FieldArray.SetValue(rs.Tables[0].Rows[0]["Allow_Duplicate"], i + 1, 4);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				FieldArray.SetValue(rs.Tables[0].Rows[0]["Allow_Null"], i + 1, 5);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				FieldArray.SetValue(rs.Tables[0].Rows[0]["Lenth"], i + 1, 6);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				FieldArray.SetValue(rs.Tables[0].Rows[0]["Type"], i + 1, 7);
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					grdMigrate1.Cols[grdMigrate1.Col].ComboList = grdMigrate1.Cols[grdMigrate1.Col].ComboList + Convert.ToString(rs.Tables[0].Rows[0]["L_Field_Name"]) + "|";
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					grdMigrate1.Cols[grdMigrate1.Col].ComboList = grdMigrate1.Cols[grdMigrate1.Col].ComboList + Convert.ToString(rs.Tables[0].Rows[0]["A_Field_Name"]) + "|";
				}
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rs.MoveNext was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rs.MoveNext();
			}
			return null;
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


		private bool VerifyData()
		{
			int i = 0; //local variable
			string ColumnName = "";
			GrdColumnProperty mColumnProp = new GrdColumnProperty();


			// check if user has selected item in migrate scheme combo
			if (cmbMigrateScheme.Text == "")
			{
				MessageBox.Show("Please select a migration scheme !!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			//Check for columns
			int tempForEndVar = FieldArray.GetLength(0) - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				ColumnName = Convert.ToString(FieldArray.GetValue(i + 1, (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? LFieldName : AFieldName));
				mColumnProp = IsColumnExists(ColumnName);
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (Convert.ToString(FieldArray.GetValue(i + 1, FieldName)) == "part_no" && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Auto_Generate_Part_No_In_Import"))) == TriState.True)
				{
					// Ignore PartNo Field
				}
				else if (!Convert.ToBoolean(FieldArray.GetValue(i + 1, AllowNull)))
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


					if (!Convert.ToBoolean(FieldArray.GetValue(i + 1, AllowDuplicate)))
					{
						if (IsColumnDuplicate(mColumnProp.tColumn))
						{
							MessageBox.Show(ColumnName + " can not be duplicate !!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							return false;
						}
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(FieldArray.GetValue(i + 1, Lenth)))
					{
						if (!IsLenthMatched(mColumnProp.tColumn, Convert.ToInt32(FieldArray.GetValue(i + 1, Lenth))))
						{
							if (MessageBox.Show(ColumnName + " lenth is more than " + Conversion.Str(FieldArray.GetValue(i + 1, Lenth)) + " !!" + "\r" + "Do you want to truncate " + ColumnName + "?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
							{
								return false;
							}
						}
					}

				}

			}

			return true;
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
				int Cnt = 0;
				string mGrdText = "";
				int mLength = 0;

				//' Creating temp table
				mysql = new StringBuilder(" create table #tmpTable (");
				Cnt = 0; // to check for value greater thn zero
				int tempForEndVar = grdMigrate1.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate1.getCellText(0, i)) != "")
					{ //if first grid(grdmigrate1) cell contain nothing then
						if (Cnt > 0)
						{
							mysql.Append(", ");
						}
						//UPGRADE_ISSUE: (2070) Constant XCOMP_EQ was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
						//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method FieldArray.Find was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						Result = FieldArray.Find(1, (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? LFieldName : AFieldName, grdMigrate1.getCellText(0, i), XORDER.DESC, UpgradeStubs.XArrayDBObject_XCOMP.getXCOMP_EQ(), XTYPE.DEFAULT);
						if (Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "C" || Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "c")
						{
							mysql.Append(Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) + " varchar(" + Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), Lenth)) + ") COLLATE SQL_Latin1_General_CP1_CI_AS ");
						}
						else if (Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "U" || Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "u")
						{ 
							mysql.Append(Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) + " nvarchar(" + Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), Lenth)) + ") COLLATE SQL_Latin1_General_CP1_CI_AS ");
						}
						else if (Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "N" || Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "n")
						{ 
							mysql.Append(Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) + " money ");
						}
						else if (Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "D" || Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "d")
						{ 
							mysql.Append(Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) + " smalldatetime");
						}
						else
						{
							mysql.Append(Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), FieldName)) + " float");
						}

						if (!Convert.ToBoolean(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), AllowNull)))
						{
							mysql.Append(" not null");
						}

						Cnt++;
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
					Cnt = 0;
					mysql = new StringBuilder("insert into #tmpTable values (");
					int tempForEndVar3 = grdMigrate1.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar3; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate1.getCellText(0, i)) != "")
						{ //if first grid(grdmigrate1) cell contain nothing then
							if (Cnt > 0)
							{
								mysql.Append(", ");
							}
							//UPGRADE_ISSUE: (2070) Constant XCOMP_EQ was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
							//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method FieldArray.Find was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							Result = FieldArray.Find(1, (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? LFieldName : AFieldName, grdMigrate1.getCellText(0, i), XORDER.DESC, UpgradeStubs.XArrayDBObject_XCOMP.getXCOMP_EQ(), XTYPE.DEFAULT);
							mLength = Convert.ToInt32(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), Lenth));
							mGrdText = (StringsHelper.Replace(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)), "'", " ", 1, -1, CompareMethod.Binary) == "") ? " null " : "'" + StringsHelper.Replace(ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)).Substring(0, Math.Min(mLength, ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)).Length)), "'", "", 1, -1, CompareMethod.Binary) + "' ";
							if (Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "C" || Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "c")
							{
								mysql.Append(mGrdText);
							}
							else if (Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "U" || Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "u")
							{ 
								if (mGrdText == " null ")
								{
									mysql.Append(mGrdText);
								}
								else
								{
									mysql.Append(" N" + SystemICSProcedure.ReplaceCharacters(mGrdText, Environment.NewLine, "\r")); // mGrdText
								}
							}
							else if (Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "N" || Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "n")
							{ 
								mysql.Append((ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)) == "") ? " Null " : ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(j, i)));
							}
							else if (Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "D" || Convert.ToString(FieldArray.GetValue(ReflectionHelper.GetPrimitiveValue<int>(Result), DataType)) == "d")
							{ 
								mysql.Append(mGrdText);
							}
							else
							{
								mysql.Append(mGrdText);
							}
							Cnt++;
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
		{

			switch(Convert.ToInt32(TableArray.GetValue(TableArray.Find(cmbMigrateScheme.Text, 1, (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? LTableName : ATableName), Table_Id)))
			{
				case 1 :  // if Item migration 
					return MigrateProducts();
				case 2 :  // if chart of accounts group 
					return MigrateChartOfAccountsGroup();
				case 3 :  // if chart of accounts ledger 
					return MigrateChartOfAccountsLedger();
				case 4 :  // if Item Alternate Unit 
					return MigrateAlternateUnit();
				case 5 :  // If Department Migration 
					return MigrateDepartment();
				case 6 :  // If Designation Migration 
					return MigrateDesignation();
				case 7 :  // If Nationality Migration 
					return MigrateNationality();
				case 8 :  // If Qualification Migration 
					return MigrateQualification();
				case 9 :  // If Bank Migration 
					return MigrateBank();
				case 10 :  // If Sponsor Migration 
					return MigrateSponsor();
				case 11 :  // If Employee Migration 
					return MigrateEmployee();
				default:
					return CommonMigration(); 

			}
		}

		private bool MigrateProducts()
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
				int Cnt = 0;

				// delete all existing records from corresponding tables
				//mySql = " delete from ICS_Item_Unit_Details"
				// gConn.Execute mySql
				//mySql = " delete from ICS_Item "
				//gConn.Execute mySql
				//mySql = " delete from ICS_Item_category Where protected = 0"
				//gConn.Execute mySql
				//mySql = " delete from ICS_Item_group Where protected = 0"
				//gConn.Execute mySql
				//mySql = " delete from ICS_Unit Where protected = 0 "
				//gConn.Execute mySql
				//mySql = " Delete from SM_VS_Static_Value Where vssv_protected = 0"
				//gConn.Execute mySql
				//mySql = " Delete from SM_Value_Set Where vs_protected = 0"
				//gConn.Execute mySql
				// end delete


				///*********************************************************************/
				//-----------------Import Data of ICS_Item Group ------------------------
				///*********************************************************************/


				mReturn = false; // check whether user has mapped l_group_name or not
				int tempForEndVar = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("L_group_Name").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturn))
				{ //if user has mapped l_group_name
					mysql = "select * from sysobjects where name = 'tmpGroup'";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					SqlDataAdapter TempAdapter = null;
					TempAdapter = new SqlDataAdapter();
					TempAdapter.SelectCommand = TempCommand;
					DataSet TempDataset = null;
					TempDataset = new DataSet();
					TempAdapter.Fill(TempDataset);
					rs = TempDataset;

					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = "drop table tmpGroup";
						TempCommand_2.ExecuteNonQuery();
					}
					rs = null;

					mReturn = false; // check whether user has mapped l_group_name or not
					int tempForEndVar2 = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar2; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("group_no").ToUpper())
						{
							mReturn = true;
							break;
						}
					}
					if (ReflectionHelper.GetPrimitiveValue<bool>(mReturn))
					{
						mysql = " select distinct group_no, l_group_name into tmpGroup from #tmpTable ";
						mysql = mysql + " Where group_no not in (select group_no from ICS_Item_group) and group_no Is Not Null and group_no <> ''";
					}
					else
					{
						mysql = " select distinct g.l_group_name into tmpGroup from #tmpTable g ";
						mysql = mysql + " Where g.l_group_name not in (select l_group_name from ICS_Item_group) and g.l_group_name Is Not Null and g.l_group_name <> ''";
					}
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					mysql = "select * from syscolumns where id = (select id from sysobjects where name = 'tmpGroup') and name = 'group_no'";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					SqlDataAdapter TempAdapter_4 = null;
					TempAdapter_4 = new SqlDataAdapter();
					TempAdapter_4.SelectCommand = TempCommand_4;
					DataSet TempDataset_4 = null;
					TempDataset_4 = new DataSet();
					TempAdapter_4.Fill(TempDataset_4);
					rs = TempDataset_4;

					if (rs.Tables[0].Rows.Count <= 0)
					{
						mysql = " select (isnull(max(group_no),0) + 1) as group_no from ICS_Item_group ";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mMaxNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
						mysql = "alter table tmpGroup add group_no int NOT NULL IDENTITY (" + mMaxNo.ToString() + ", 1)";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}

					mysql = "insert into ICS_Item_group (m_group_cd, group_no, l_group_name, user_cd) ";
					mysql = mysql + " select 1, group_no , l_group_name, 1 from tmpGroup";
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();
				}
				///****************************** ICS_Item Group  End ***************************************/


				///*********************************************************************/
				//--------------------Import Data of ICS_Item Category-------------------
				///*********************************************************************/

				mReturn = false; // check whether user has mapped l_cat_name or not
				int tempForEndVar3 = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar3; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("l_cat_name").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturn))
				{ //if l_cat_name field name exists then

					mysql = "select * from sysobjects where name = 'tmpCategory'";

					SqlCommand TempCommand_7 = null;
					TempCommand_7 = SystemVariables.gConn.CreateCommand();
					TempCommand_7.CommandText = mysql;
					SqlDataAdapter TempAdapter_7 = null;
					TempAdapter_7 = new SqlDataAdapter();
					TempAdapter_7.SelectCommand = TempCommand_7;
					DataSet TempDataset_7 = null;
					TempDataset_7 = new DataSet();
					TempAdapter_7.Fill(TempDataset_7);
					rs = TempDataset_7;

					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_8 = null;
						TempCommand_8 = SystemVariables.gConn.CreateCommand();
						TempCommand_8.CommandText = "drop table tmpCategory";
						TempCommand_8.ExecuteNonQuery();
					}
					rs = null;

					mReturn = false; // check whether user has mapped cat_no or not
					int tempForEndVar4 = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar4; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("cat_no").ToUpper())
						{
							mReturn = true;
							break;
						}
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(mReturn))
					{
						mysql = " select distinct p.cat_no, p.l_cat_name into tmpCategory from #tmpTable p ";
						mysql = mysql + " Where cat_no not in (select cat_no from ICS_Item_category) and cat_no Is Not Null and cat_no <> ''";
					}
					else
					{
						mysql = " select distinct c.l_cat_name into tmpCategory from #tmpTable c";
						mysql = mysql + " Where c.l_cat_name not in (select l_cat_name from ICS_Item_category) and  c.l_cat_name Is Not Null and c.l_cat_name <> '' ";
					}
					SqlCommand TempCommand_9 = null;
					TempCommand_9 = SystemVariables.gConn.CreateCommand();
					TempCommand_9.CommandText = "select * from ICS_Item_category";
					SqlDataAdapter TempAdapter_9 = null;
					TempAdapter_9 = new SqlDataAdapter();
					TempAdapter_9.SelectCommand = TempCommand_9;
					DataSet TempDataset_9 = null;
					TempDataset_9 = new DataSet();
					TempAdapter_9.Fill(TempDataset_9);
					rs = TempDataset_9;
					SqlCommand TempCommand_10 = null;
					TempCommand_10 = SystemVariables.gConn.CreateCommand();
					TempCommand_10.CommandText = mysql;
					TempCommand_10.ExecuteNonQuery();


					mysql = " select * from syscolumns where id =( select id from sysobjects where name = 'tmpCategory') and name = 'cat_no'";
					SqlCommand TempCommand_11 = null;
					TempCommand_11 = SystemVariables.gConn.CreateCommand();
					TempCommand_11.CommandText = mysql;
					SqlDataAdapter TempAdapter_11 = null;
					TempAdapter_11 = new SqlDataAdapter();
					TempAdapter_11.SelectCommand = TempCommand_11;
					DataSet TempDataset_11 = null;
					TempDataset_11 = new DataSet();
					TempAdapter_11.Fill(TempDataset_11);
					rs = TempDataset_11;
					if (rs.Tables[0].Rows.Count <= 0)
					{
						mysql = " select (isnull(max(cat_no),0) + 1) as cat_no from ICS_Item_category ";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mMaxNo = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
						mysql = "alter table tmpCategory add cat_no int NOT NULL IDENTITY (" + mMaxNo.ToString() + ", 1)";
						SqlCommand TempCommand_12 = null;
						TempCommand_12 = SystemVariables.gConn.CreateCommand();
						TempCommand_12.CommandText = mysql;
						TempCommand_12.ExecuteNonQuery();
					}

					mysql = " insert into ICS_Item_category (m_cat_cd, cat_no, l_cat_name, user_cd) ";
					mysql = mysql + " select 1, cat_no, l_cat_name, 1 from tmpCategory ";
					SqlCommand TempCommand_13 = null;
					TempCommand_13 = SystemVariables.gConn.CreateCommand();
					TempCommand_13.CommandText = mysql;
					TempCommand_13.ExecuteNonQuery();


				}
				///******************************End Category Master************************************/


				///*********************************************************************/
				//--------------------Import Data of ICS_Unit Symbol------------------------
				///*********************************************************************/
				mReturn = false; // check whether user has mapped unit_symbol or not
				int tempForEndVar5 = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar5; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("unit_symbol").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturn))
				{ //if tmpUnit table exists then drop
					mysql = " select * from sysobjects where name = 'tmpUnit'";
					SqlCommand TempCommand_14 = null;
					TempCommand_14 = SystemVariables.gConn.CreateCommand();
					TempCommand_14.CommandText = mysql;
					SqlDataAdapter TempAdapter_14 = null;
					TempAdapter_14 = new SqlDataAdapter();
					TempAdapter_14.SelectCommand = TempCommand_14;
					DataSet TempDataset_14 = null;
					TempDataset_14 = new DataSet();
					TempAdapter_14.Fill(TempDataset_14);
					rs = TempDataset_14;
					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_15 = null;
						TempCommand_15 = SystemVariables.gConn.CreateCommand();
						TempCommand_15.CommandText = " drop table tmpUnit";
						TempCommand_15.ExecuteNonQuery();
					}

					mReturn = false; // check whether user has mapped cat_no or not
					int tempForEndVar6 = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar6; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("unit_no").ToUpper())
						{
							mReturn = true;
							break;
						}
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(mReturn))
					{
						mysql = " select distinct unit_no, unit_symbol into tmpUnit from #tmpTable ";
						mysql = mysql + " Where unit_no Is Not Null or unit_no <> ''";
					}
					else
					{
						mysql = " select distinct unit_symbol into tmpUnit from #tmpTable Where unit_symbol Is Not Null or unit_symbol <> ''";
					}
					SqlCommand TempCommand_16 = null;
					TempCommand_16 = SystemVariables.gConn.CreateCommand();
					TempCommand_16.CommandText = mysql;
					TempCommand_16.ExecuteNonQuery();


					mysql = " select * from syscolumns where id = ( select id from sysobjects where name = 'tmpUnit') and name = 'unit_no'";
					SqlCommand TempCommand_17 = null;
					TempCommand_17 = SystemVariables.gConn.CreateCommand();
					TempCommand_17.CommandText = mysql;
					SqlDataAdapter TempAdapter_17 = null;
					TempAdapter_17 = new SqlDataAdapter();
					TempAdapter_17.SelectCommand = TempCommand_17;
					DataSet TempDataset_17 = null;
					TempDataset_17 = new DataSet();
					TempAdapter_17.Fill(TempDataset_17);
					rs = TempDataset_17;
					if (rs.Tables[0].Rows.Count <= 0)
					{
						mysql = " alter table tmpUnit add unit_no int NOT NULL IDENTITY (200, 1)";
						SqlCommand TempCommand_18 = null;
						TempCommand_18 = SystemVariables.gConn.CreateCommand();
						TempCommand_18.CommandText = mysql;
						TempCommand_18.ExecuteNonQuery();
					}
					mysql = " insert into ICS_Unit (unit_no, l_unit_name, a_unit_name, symbol, user_cd) select unit_no, unit_symbol, unit_symbol, unit_symbol, ";
					mysql = mysql + " 1 from tmpUnit where unit_symbol not in (select symbol from ICS_unit)";
					SqlCommand TempCommand_19 = null;
					TempCommand_19 = SystemVariables.gConn.CreateCommand();
					TempCommand_19.CommandText = mysql;
					TempCommand_19.ExecuteNonQuery();
				}
				///*********************************************************************/

				///*********************************************************************/
				//-------------------Import Data of Suppliers---------------------------
				///*********************************************************************/
				//
				//mReturn = False    ' check whether user has mapped supplier_name or not
				//For i = 0 To grdMigrate2.cols - 1
				//    If UCase(grdMigrate2.Cell(flexcpText, 0, i)) = UCase("supplier_name") Then
				//        mReturn = True
				//        Exit For
				//    End If
				//Next i
				//
				//If mReturn = True Then 'if tmpSupplier table name exists then drop the table
				//    mySql = " select * from sysobjects where name = 'tmpSupplier'"
				//    Set rs = cn.Execute(mySql)
				//    If rs.RecordCount > 0 Then
				//        cn.Execute " drop table tmpSupplier"
				//    End If
				//
				//
				//    mReturn = False    ' check whether user has mapped supplier_code or not
				//    For i = 0 To grdMigrate2.cols - 1
				//        If UCase(grdMigrate2.Cell(flexcpText, 0, i)) = UCase("ldgr_no") Then
				//            mReturn = True
				//            Exit For
				//        End If
				//    Next i
				//
				//    If mReturn = True Then
				//        mySql = " select distinct ldgr_no,  supplier_name into tmpSupplier from #tmpTable Where ldgr_no Is Not Null or ldgr_no <> ''"
				//    Else
				//        mySql = " select distinct supplier_name into tmpSupplier from #tmpTable Where supplier_name Is Not Null or supplier_name <> '' "
				//    End If
				//    cn.Execute mySql
				//
				//
				//    mySql = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSupplier') and name = 'ldgr_no'"
				//    Set rs = gConn.Execute(mySql)
				//    If rs.RecordCount <= 0 Then
				//        mySql = " alter table tmpSupplier add ldgr_no int NOT NULL IDENTITY (200, 1)"
				//        gConn.Execute mySql
				//    End If
				//
				//
				//    mySql = "insert into gl_ledger (type_cd,group_cd,curr_cd,Ldgr_No,L_Ldgr_Name,a_Ldgr_Name,User_Cd) "
				//    mySql = mySql & " select 3,1026, 1, ldgr_no, supplier_name,supplier_name,1 from tmpSupplier"
				//    mySql = mySql & " where supplier_name not in (select L_Ldgr_Name from gl_ledger)"
				//    gConn.Execute mySql
				//End If
				///*********************************End Supplier****************************************/


				///*********************************************************************/
				//-----------------------Import Data of ICS_Items-------------------------
				///*********************************************************************/

				//in database there are certain fields which are supposed to be hardcoded and rest fields should be added dynamically
				//eg. partno, ICS_Itemname groupcd,unitcd has to be hardcoded and rest fields should be added in insert statement dynamically
				StringBuilder XtraSQL = new StringBuilder();
				string GrdFieldName = "";
				XtraSQL = new StringBuilder("");
				int tempForEndVar7 = grdMigrate2.Cols.Count - 1;
				for (i = 1; i <= tempForEndVar7; i++)
				{
					GrdFieldName = ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper();
					if (!(GrdFieldName == "PART_NO" || GrdFieldName == "L_PROD_NAME" || GrdFieldName == "UNIT_SYMBOL" || GrdFieldName == "GROUP_NO" || GrdFieldName == "L_GROUP_NAME" || GrdFieldName == "CAT_NO" || GrdFieldName == "L_CAT_NAME" || GrdFieldName == "UNIT_NO" || GrdFieldName == "SUPPLIER_NAME" || GrdFieldName == "LDGR_NO" || GrdFieldName == "FLEX1" || GrdFieldName == "FLEX2" || GrdFieldName == "FLEX3" || GrdFieldName == "FLEX4" || GrdFieldName == "FLEX5" || GrdFieldName == "FLEX6" || GrdFieldName == "FLEX7" || GrdFieldName == "FLEX8" || GrdFieldName == "FLEX9" || GrdFieldName == "FLEX10" || GrdFieldName == "FLEX11" || GrdFieldName == "FLEX12" || GrdFieldName == "FLEX13" || GrdFieldName == "FLEX14" || GrdFieldName == "A_PROD_NAME" || GrdFieldName == "BARCODE"))
					{
						XtraSQL.Append(", p." + GrdFieldName.ToLower());
					}

				}


				mysql = "  insert into ICS_Item (part_no, l_prod_name, a_prod_name, base_unit_cd, report_unit_cd, group_cd, cat_cd ";
				mysql = mysql + " ,Supplier_ldgr_cd, user_cd" + XtraSQL.ToString() + ")";
				mysql = mysql + " select ";

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Auto_Generate_Part_No_In_Import"))) == TriState.True)
				{
					mysql = mysql + " '-' + cast(ROW_NUMBER() OVER(ORDER BY p.part_no ASC) as varchar(20)) AS Part_No, ";
				}
				else
				{
					mysql = mysql + " p.part_no, ";
				}
				mysql = mysql + " p.l_prod_name ";

				if (IsFieldExist("a_prod_name"))
				{
					mysql = mysql + " , isnull(p.a_prod_name, '') ";
				}
				else
				{
					mysql = mysql + " , '' ";
				}

				if (IsFieldExist("unit_symbol"))
				{
					mysql = mysql + " , isnull((select unit_cd from ICS_Unit where symbol = p.unit_symbol), 1) as unit_cd ";
					mysql = mysql + " , isnull((select unit_cd from ICS_Unit where symbol = p.unit_symbol), 1) as report_unit_cd ";
				}
				else
				{
					mysql = mysql + " , 1 as unit_cd ";
					mysql = mysql + " , 1 as report_unit_cd ";
				}

				if (IsFieldExist("l_group_name"))
				{
					mysql = mysql + " , isnull((select group_cd from ICS_Item_group where l_group_name = p.l_group_name), 1) as group_cd ";

				}
				else if (IsFieldExist("GROUP_NO"))
				{ 
					mysql = mysql + " , isnull((select group_cd from ICS_Item_group where group_no = p.group_no), 1) as group_cd ";
				}
				else
				{
					mysql = mysql + " , 1 as group_cd ";
				}

				if (IsFieldExist("l_cat_name"))
				{
					mysql = mysql + " , isnull((select cat_cd from ICS_Item_category where l_cat_name = p.l_cat_name), 1) as cat_cd ";
				}
				else if (IsFieldExist("CAT_NO"))
				{ 
					mysql = mysql + " , isnull((select cat_cd from ICS_Item_category where cat_no = p.CAT_NO), 1) as cat_cd ";
				}
				else
				{
					mysql = mysql + " , 1 as cat_cd ";
				}

				if (IsFieldExist("ldgr_no"))
				{
					mysql = mysql + " , (select ldgr_cd from gl_ledger where ldgr_no=p.ldgr_no) as supplier_ldgr_cd ";
				}
				else
				{
					mysql = mysql + " ,null ";
				}

				//user code
				mysql = mysql + " ,  1 " + XtraSQL.ToString();

				mysql = mysql + " from #tmpTable p LEFT OUTER JOIN ICS_Item on p.part_no = ICS_Item.part_no ";
				mysql = mysql + " Where p.l_prod_name Is Not Null and ICS_Item.part_no Is Null";
				SqlCommand TempCommand_20 = null;
				TempCommand_20 = SystemVariables.gConn.CreateCommand();
				TempCommand_20.CommandText = mysql;
				TempCommand_20.ExecuteNonQuery();
				///********************************End ICS_Items*********************************/

				///*********************************************************************/
				//---------=-----------------Set Barcode-------------------------------
				///*********************************************************************/


				if (IsFieldExist("barcode"))
				{
					mysql = "insert into ICS_Item_barcode_details (prod_cd, barcode, unit_entry_id)";
					mysql = mysql + " select ICS_Item.prod_cd, b.barcode, (select unit_entry_id from ICS_Item_Unit_Details aud ";
					mysql = mysql + " Where aud.prod_cd = ICS_Item.prod_cd and aud.base_unit_cd = aud.alt_unit_cd) ";
					mysql = mysql + " From ICS_Item inner join #tmpTable b on ICS_Item.part_no = b.part_no ";
					mysql = mysql + " where b.barcode is not null";
					SqlCommand TempCommand_21 = null;
					TempCommand_21 = SystemVariables.gConn.CreateCommand();
					TempCommand_21.CommandText = mysql;
					TempCommand_21.ExecuteNonQuery();
				}
				///*************************End Barcode*********************************/

				///*********************************************************************/
				//---------------Add Values is SM_Value_Set Table -----------------------
				///*********************************************************************/

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Auto_Generate_Part_No_In_Import"))) == TriState.True)
				{
					mysql = "exec SP_Import_Generate_Part_No ";
					SqlCommand TempCommand_22 = null;
					TempCommand_22 = SystemVariables.gConn.CreateCommand();
					TempCommand_22.CommandText = mysql;
					TempCommand_22.ExecuteNonQuery();
				}

				///*********************************************************************/
				//-------------------------Flex1 Name----------------------------------
				///*********************************************************************/

				for (Cnt = 1; Cnt <= 14; Cnt++)
				{

					if (IsFieldExist("flex" + Cnt.ToString()))
					{

						//    mySql = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
						//    mySql = mySql & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
						//    mySql = mySql & " values ('ICS_Item', 1 , 'Flex1' , 'Flex1' , N'Flex1' , N'Flex1' , N'Flex1' , 1 )"
						//    gConn.Execute mySql

						mVSCode = Cnt;

						mysql = "select * from sysobjects where name = 'tmpSValues'";
						SqlCommand TempCommand_23 = null;
						TempCommand_23 = SystemVariables.gConn.CreateCommand();
						TempCommand_23.CommandText = mysql;
						SqlDataAdapter TempAdapter_23 = null;
						TempAdapter_23 = new SqlDataAdapter();
						TempAdapter_23.SelectCommand = TempCommand_23;
						DataSet TempDataset_23 = null;
						TempDataset_23 = new DataSet();
						TempAdapter_23.Fill(TempDataset_23);
						rs = TempDataset_23;
						if (rs.Tables[0].Rows.Count > 0)
						{
							SqlCommand TempCommand_24 = null;
							TempCommand_24 = SystemVariables.gConn.CreateCommand();
							TempCommand_24.CommandText = "drop table tmpSValues";
							TempCommand_24.ExecuteNonQuery();
						}

						mysql = "select distinct Flex" + mVSCode.ToString() + " as vs_l_name into tmpSValues from #tmpTable Where Flex" + mVSCode.ToString() + "  Is Not Null ";
						mysql = mysql + " and flex" + mVSCode.ToString() + "  not in ( select svsv.vssv_l_name ";
						mysql = mysql + " from SM_Value_Set svs ";
						mysql = mysql + " inner join SM_VS_Static_Value svsv on svs.entry_id = svsv.entry_id ";
						mysql = mysql + " where svs.vs_object_type = 'ICS_Item' ";
						mysql = mysql + " and svs.vs_code = " + mVSCode.ToString() + " ) ";

						SqlCommand TempCommand_25 = null;
						TempCommand_25 = SystemVariables.gConn.CreateCommand();
						TempCommand_25.CommandText = mysql;
						SqlDataAdapter TempAdapter_25 = null;
						TempAdapter_25 = new SqlDataAdapter();
						TempAdapter_25.SelectCommand = TempCommand_25;
						DataSet TempDataset_25 = null;
						TempDataset_25 = new DataSet();
						TempAdapter_25.Fill(TempDataset_25);
						rs = TempDataset_25;

						mysql = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'";
						SqlCommand TempCommand_26 = null;
						TempCommand_26 = SystemVariables.gConn.CreateCommand();
						TempCommand_26.CommandText = mysql;
						SqlDataAdapter TempAdapter_26 = null;
						TempAdapter_26 = new SqlDataAdapter();
						TempAdapter_26.SelectCommand = TempCommand_26;
						DataSet TempDataset_26 = null;
						TempDataset_26 = new DataSet();
						TempAdapter_26.Fill(TempDataset_26);
						rs = TempDataset_26;
						if (rs.Tables[0].Rows.Count <= 0)
						{
							mysql = " select  (isnull(max(svsv.vssv_code), 0) + 1 ) ";
							mysql = mysql + " from SM_Value_Set svs ";
							mysql = mysql + " inner join SM_VS_Static_Value svsv on svs.entry_id = svsv.entry_id ";
							mysql = mysql + " where svs.vs_object_type = 'ICS_Item' ";
							mysql = mysql + " and svs.vs_code = " + mVSCode.ToString();
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturn = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1068) mReturn of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mMaxNo = ReflectionHelper.GetPrimitiveValue<int>(mReturn);
							SqlCommand TempCommand_27 = null;
							TempCommand_27 = SystemVariables.gConn.CreateCommand();
							TempCommand_27.CommandText = " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (" + Conversion.Str(mMaxNo) + " , 1)";
							TempCommand_27.ExecuteNonQuery();
						}

						mysql = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name ";
						mysql = mysql + " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'ICS_Item' ";
						mysql = mysql + " and vs_code =  " + mVSCode.ToString() + " ) ";
						mysql = mysql + " , vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues ";
						SqlCommand TempCommand_28 = null;
						TempCommand_28 = SystemVariables.gConn.CreateCommand();
						TempCommand_28.CommandText = mysql;
						TempCommand_28.ExecuteNonQuery();

						mysql = " Update ICS_Item set Flex" + mVSCode.ToString() + "_VSSV_Code = svsv.vssv_code ";
						mysql = mysql + " from SM_VS_Static_Value svsv ";
						mysql = mysql + " left outer join #tmpTable tp on tp.Flex" + mVSCode.ToString() + " = svsv.vssv_l_name ";
						mysql = mysql + " inner join ICS_Item p on p.part_no = tp.part_no ";
						mysql = mysql + " inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id ";
						mysql = mysql + " where sv.vs_object_type = 'ICS_Item' and sv.vs_code =" + mVSCode.ToString();
						SqlCommand TempCommand_29 = null;
						TempCommand_29 = SystemVariables.gConn.CreateCommand();
						TempCommand_29.CommandText = mysql;
						TempCommand_29.ExecuteNonQuery();
					}
				}
				///*********************************************************************/


				//'/*********************************************************************/
				//'-------------------------Flex2 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex2") = True Then
				//
				//'    mySql = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//'    mySql = mySql & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//'    mySql = mySql & " values ('Product', 2 , 'Flex2' , 'Flex2' , N'Flex2' , N'Flex2' , N'Flex2' , 1 )"
				//'    gConn.Execute mySql
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex1 as vs_l_name into tmpSValues from #tmpTable Where Flex1 Is Not Null "
				//    mySQL = mySQL & " and flex1 not in ( select  svsv.vssv_l_name "
				//    mySQL = mySQL & " from SM_Value_Set svs"
				//    mySQL = mySQL & " inner join SM_VS_Static_Value svsv on svs.entry_id = svsv.entry_id "
				//    mySQL = mySQL & " where svs.vs_object_type = 'product' "
				//    mySQL = mySQL & " and svs.vs_code = 2) "
				//
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        mySQL = " select  (isnull(max(svsv.vssv_code), 0) + 1 ) "
				//        mySQL = mySQL & " from SM_Value_Set svs "
				//        mySQL = mySQL & " inner join SM_VS_Static_Value svsv on svs.entry_id = svsv.entry_id "
				//        mySQL = mySQL & " where svs.vs_object_type = 'Product' "
				//        mySQL = mySQL & " and svs.vs_code = 2 "
				//        mReturn = GetMasterCode(mySQL)
				//        mMaxNo = mReturn
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (" & Str(mMaxNo) & " , 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 1), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex1_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex1 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 1 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//'/*********************************************************************/
				//'-------------------------Flex3 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex3") = True Then
				//
				//'    mySql = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//'    mySql = mySql & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//'    mySql = mySql & " values ('Product', 3 , 'Flex3' , 'Flex3' , N'Flex3' , N'Flex3' , N'Flex3' , 1 )"
				//'    gConn.Execute mySql
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex3 as vs_l_name into tmpSValues from #tmpTable Where Flex3 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 3), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex3_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex3 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex3%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 3 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//'/*********************************************************************/
				//'-------------------------Flex4 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex4") = True Then
				//
				//'    mySql = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//'    mySql = mySql & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//'    mySql = mySql & " values ('Product', 4 , 'Flex4' , 'Flex4' , N'Flex4' , N'Flex4' , N'Flex4' , 1 )"
				//'    gConn.Execute mySql
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex4 as vs_l_name into tmpSValues from #tmpTable Where Flex4 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 4), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex4_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex4 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex4%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 4 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//
				//'/*********************************************************************/
				//'-------------------------Flex5 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex5") = True Then
				//
				//'    mySql = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//'    mySql = mySql & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//'    mySql = mySql & " values ('Product', 5 , 'Flex5' , 'Flex5' , N'Flex5' , N'Flex5' , N'Flex5' , 1 )"
				//'    gConn.Execute mySql
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex5 as vs_l_name into tmpSValues from #tmpTable Where Flex5 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 5), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex5_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex5 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex5%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 5 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//'/*********************************************************************/
				//'-------------------------Flex6 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex6") = True Then
				//
				//'    mySql = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//'    mySql = mySql & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//'    mySql = mySql & " values ('Product', 6 , 'Flex6' , 'Flex6' , N'Flex6' , N'Flex6' , N'Flex6' , 1 )"
				//'    gConn.Execute mySql
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex6 as vs_l_name into tmpSValues from #tmpTable Where Flex6 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 6), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex6_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex6 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex6%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 6 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//'/*********************************************************************/
				//'-------------------------Flex7 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex7") = True Then
				//
				//'    mySql = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//'    mySql = mySql & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//'    mySql = mySql & " values ('Product', 7 , 'Flex7' , 'Flex7' , N'Flex7' , N'Flex7' , N'Flex7' , 1 )"
				//'    gConn.Execute mySql
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex7 as vs_l_name into tmpSValues from #tmpTable Where Flex7 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 7), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex7_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex7 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex7%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 7 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//'/*********************************************************************/
				//'-------------------------Flex8 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex8") = True Then
				//
				//    mySQL = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//    mySQL = mySQL & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//    mySQL = mySQL & " values ('Product', 8 , 'Flex8' , 'Flex8' , N'Flex8' , N'Flex8' , N'Flex8' , 1 )"
				//    gConn.Execute mySQL
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex8 as vs_l_name into tmpSValues from #tmpTable Where Flex8 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from S_value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 8), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex8_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex8 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex8%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 8 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//'/*********************************************************************/
				//'-------------------------Flex9 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex9") = True Then
				//
				//    mySQL = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//    mySQL = mySQL & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//    mySQL = mySQL & " values ('Product', 9 , 'Flex9' , 'Flex9' , N'Flex9' , N'Flex9' , N'Flex9' , 1 )"
				//    gConn.Execute mySQL
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex9 as vs_l_name into tmpSValues from #tmpTable Where Flex9 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 9), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex9_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex9 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex9%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 9 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//
				//'/*********************************************************************/
				//'-------------------------Flex10 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex10") = True Then
				//
				//    mySQL = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//    mySQL = mySQL & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//    mySQL = mySQL & " values ('Product', 10 , 'Flex10' , 'Flex10' , N'Flex10' , N'Flex10' , N'Flex10' , 1 )"
				//    gConn.Execute mySQL
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex10 as vs_l_name into tmpSValues from #tmpTable Where Flex10 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 10), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex10_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex10 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex10%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 10 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//
				//'/*********************************************************************/
				//'-------------------------Flex11 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex11") = True Then
				//
				//    mySQL = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//    mySQL = mySQL & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//    mySQL = mySQL & " values ('Product', 11 , 'Flex11' , 'Flex11' , N'Flex11' , N'Flex11' , N'Flex11' , 1 )"
				//    gConn.Execute mySQL
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex11 as vs_l_name into tmpSValues from #tmpTable Where Flex11 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 11), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex11_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex11 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex11%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 11 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//'/*********************************************************************/
				//'-------------------------Flex12 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex12") = True Then
				//
				//    mySQL = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//    mySQL = mySQL & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//    mySQL = mySQL & " values ('Product', 12 , 'Flex12' , 'Flex12' , N'Flex12' , N'Flex12' , N'Flex12' , 1 )"
				//    gConn.Execute mySQL
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex12 as vs_l_name into tmpSValues from #tmpTable Where Flex12 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 12), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex12_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex12 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex12%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 12 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//'/*********************************************************************/
				//'-------------------------Flex13 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex13") = True Then
				//
				//    mySQL = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//    mySQL = mySQL & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//    mySQL = mySQL & " values ('Product', 13 , 'Flex13' , 'Flex13' , N'Flex13' , N'Flex13' , N'Flex13' , 1 )"
				//    gConn.Execute mySQL
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex13 as vs_l_name into tmpSValues from #tmpTable Where Flex13 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 13), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex13_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex13 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex13%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 13 "
				//    gConn.Execute mySQL
				//
				//End If
				//
				//'/*********************************************************************/
				//
				//'/*********************************************************************/
				//'-------------------------Flex14 Name----------------------------------
				//'/*********************************************************************/
				//
				//If IsFieldExist("Flex14") = True Then
				//
				//    mySQL = " insert into SM_Value_Set  (vs_object_type, vs_code, vs_l_name "
				//    mySQL = mySQL & " , vs_l_short_name, vs_a_name, vs_a_short_name, vs_remarks  , user_cd) "
				//    mySQL = mySQL & " values ('Product', 14 , 'Flex14' , 'Flex14' , N'Flex14' , N'Flex14' , N'Flex14' , 1 )"
				//    gConn.Execute mySQL
				//
				//    mySQL = "select * from sysobjects where name = 'tmpSValues'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount > 0 Then
				//        gConn.Execute "drop table tmpSValues"
				//    End If
				//
				//    mySQL = "select distinct Flex14 as vs_l_name into tmpSValues from #tmpTable Where Flex14 Is Not Null"
				//    Set rs = gConn.Execute(mySQL)
				//
				//    mySQL = "select * from syscolumns where id = ( select id from sysobjects where name = 'tmpSValues') and name = 'vssv_code'"
				//    Set rs = gConn.Execute(mySQL)
				//    If rs.RecordCount <= 0 Then
				//        gConn.Execute " alter table tmpSValues add vssv_code int NOT NULL IDENTITY (1, 1)"
				//    End If
				//
				//    mySQL = " insert into SM_VS_Static_Value (entry_id, vssv_code , vssv_l_name , vssv_l_short_name, vssv_a_name "
				//    mySQL = mySQL & " , vssv_a_short_name , user_cd) select (select entry_id from SM_Value_Set where vs_object_type = 'Product' "
				//    mySQL = mySQL & " and vs_code = 14), vssv_code, vs_l_name, vs_l_name, vs_l_name, vs_l_name, 1 From tmpSValues"
				//    gConn.Execute mySQL
				//
				//    mySQL = " Update ICS_Item set Flex14_VSSV_Code = svsv.vssv_code from SM_VS_Static_Value svsv left outer join #tmpTable tp on tp.Flex14 = svsv.vssv_l_name "
				//    mySQL = mySQL & " inner join ICS_Item p on p.part_no = tp.part_no inner join SM_Value_Set sv on sv.entry_id=svsv.entry_id"
				//    'mySql = mySql & " where sv.vs_l_name like '%Flex14%' "
				//    mySQL = mySQL & " where sv.vs_object_type = 'Product' and sv.vs_code = 14 "
				//    gConn.Execute mySQL
				//
				//End If
				//'/*********************************************************************/

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

		private bool MigrateChartOfAccountsGroup()
		{
			bool result = false;
			string mysql = "";
			try
			{
				int i = 0;
				object mReturn = null;
				DataSet rs = null;

				mysql = "insert into gl_accnt_group (group_no, l_group_name, a_group_name, ag_type_cd, user_cd) ";
				mysql = mysql + " select group_no, l_group_name, a_group_name, ag_type_cd, 1 from #tmpTable where group_no not in (select group_no from gl_accnt_group) ";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = "select group_no, parent_group_no From #tmpTable Where group_no Is Not Null";
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				SqlDataAdapter TempAdapter_2 = null;
				TempAdapter_2 = new SqlDataAdapter();
				TempAdapter_2.SelectCommand = TempCommand_2;
				DataSet TempDataset_2 = null;
				TempDataset_2 = new DataSet();
				TempAdapter_2.Fill(TempDataset_2);
				rs = TempDataset_2;
				DataSet tmpRs = null;

				foreach (DataRow iteration_row in rs.Tables[0].Rows)
				{
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = "select group_cd from gl_accnt_group where group_no = '" + Convert.ToString(iteration_row["parent_group_no"]) + "'";
					SqlDataAdapter TempAdapter_3 = null;
					TempAdapter_3 = new SqlDataAdapter();
					TempAdapter_3.SelectCommand = TempCommand_3;
					DataSet TempDataset_3 = null;
					TempDataset_3 = new DataSet();
					TempAdapter_3.Fill(TempDataset_3);
					tmpRs = TempDataset_3;
					if (tmpRs.Tables[0].Rows.Count > 0)
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mysql = "update gl_accnt_group set m_group_cd = " + ((Convert.IsDBNull(tmpRs.Tables[0].Rows[0][0])) ? " null " : Convert.ToString(tmpRs.Tables[0].Rows[0][0])) + " where group_no = '" + Convert.ToString(iteration_row["group_no"]) + "'";
						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();
					}
				}


				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(mysql + "\r" + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				result = false;
			}
			return result;
		}

		private bool MigrateChartOfAccountsLedger()
		{
			bool result = false;
			string mysql = "";
			try
			{
				int i = 0;
				object mReturn = null;
				DataSet rs = null;

				StringBuilder XtraSQL = new StringBuilder();
				string GrdFieldName = "";
				XtraSQL = new StringBuilder("");
				int tempForEndVar = grdMigrate2.Cols.Count - 1;
				for (i = 1; i <= tempForEndVar; i++)
				{
					GrdFieldName = ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper();
					if (!(GrdFieldName == "TYPE_CD" || GrdFieldName == "GROUP_NO" || GrdFieldName == "L_CURR_NAME" || GrdFieldName == "LDGR_NO" || GrdFieldName == "L_LDGR_NAME" || GrdFieldName == "A_LDGR_NAME"))
					{
						XtraSQL.Append(", " + GrdFieldName.ToLower());
					}

				}

				mysql = "insert into gl_ledger (type_cd, group_cd, curr_cd, ldgr_no, l_ldgr_name ";
				if (IsFieldExist("a_ldgr_name"))
				{
					mysql = mysql + " , a_ldgr_name ";
				}
				mysql = mysql + ", user_cd " + XtraSQL.ToString() + ") ";
				mysql = mysql + " select type_cd, (select group_cd from gl_accnt_group where group_no = l.group_no) ";
				mysql = mysql + ", 1, ldgr_no, l_ldgr_name";
				if (IsFieldExist("a_ldgr_name"))
				{
					mysql = mysql + ", isnull(a_ldgr_name,'') ";
				}
				mysql = mysql + ",1 " + XtraSQL.ToString() + " from #tmpTable l where ldgr_no not in (select ldgr_no from gl_ledger) ";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(mysql + "\r" + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				result = false;
			}
			return result;
		}

		private bool MigrateAlternateUnit()
		{
			bool result = false;
			string mysql = "";
			try
			{
				int i = 0;
				object mReturn = null;
				DataSet rs = null;

				string XtraSQL = "";
				string GrdFieldName = "";
				//XtraSQL = ""
				//For i = 1 To grdMigrate2.cols - 1
				//    GrdFieldName = UCase(grdMigrate2.Cell(flexcpText, 0, i))
				//    If GrdFieldName = "TYPE_CD" Or GrdFieldName = "GROUP_NO" Or _
				//'        GrdFieldName = "L_CURR_NAME" Or GrdFieldName = "LDGR_NO" Or _
				//'        GrdFieldName = "L_LDGR_NAME" Or GrdFieldName = "A_LDGR_NAME" Then
				//        GoTo MoveNext
				//    Else
				//        XtraSQL = XtraSQL & ", " & LCase(GrdFieldName)
				//    End If
				//MoveNext:
				//Next

				mysql = "insert into ICS_Item_Unit_Details (Prod_Cd, Alt_Unit_Cd, Base_Unit_Cd, Base_Qty, Alt_Qty, ";
				mysql = mysql + " Line_No, Protected, user_cd ) ";

				mysql = mysql + " select i.prod_cd ";
				mysql = mysql + ", (select unit_cd from ICS_Unit where Symbol = l.Unit_Symbol)";
				mysql = mysql + ", i.base_unit_cd, l.Base_Qty, l.Alt_Qty";
				mysql = mysql + ",(select max(line_no) from ICS_Item_Unit_Details where prod_cd = i.prod_cd) + 1 ";
				mysql = mysql + ", 0, " + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " from #tmpTable l inner join ICS_Item i on l.part_no = i.part_no";
				mysql = mysql + " where prod_cd not in (select iu.prod_cd from ICS_Item_Unit_Details iu inner join ICS_Unit u on iu.alt_unit_cd = u.unit_cd";
				mysql = mysql + " where prod_cd = i.prod_cd and u.symbol = l.Unit_Symbol) ";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				return true;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(mysql + "\r" + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				result = false;
			}
			return result;
		}


		private bool CommonMigration()
		{
			string GrdFieldName = "";
			int i = 0;
			StringBuilder mSqlForFields = new StringBuilder();
			string mysql = "";
			int mReturn = TableArray.Find(cmbMigrateScheme.Text, 1, (SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? LFieldName : AFieldName);
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			string mTableName = (Convert.IsDBNull(TableArray.GetValue(mReturn + 1, TableName))) ? "" : Convert.ToString(TableArray.GetValue(mReturn + 1, TableName));
			mysql = " insert into " + mTableName + "(";
			int tempForEndVar = grdMigrate2.Cols.Count - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				if (i != 0 && GrdFieldName != "")
				{
					mSqlForFields.Append(", ");
				}
				GrdFieldName = ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper();
				mSqlForFields.Append(GrdFieldName.ToLower());
			}

			mysql = mysql + mSqlForFields.ToString() + ") select " + mSqlForFields.ToString() + " from #tmpTable ";

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
			return true;
			//MsgBox mysql
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

		private bool MigrateDepartment()
		{ // to migrate Department data
			bool result = false;
			string mysql = "";
			try
			{
				int i = 0;
				object mReturn = null;
				DataSet rs = null;
				int mMaxNo = 0;
				int mVSCode = 0;
				int Cnt = 0;
				int mPDept = 0;

				///*********************************************************************/
				//-----------------Import Data of Parent Department --------------------
				///*********************************************************************/
				mysql = " select dept_cd from pay_department where dept_no = 1 ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturn = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturn))
				{
					MessageBox.Show("Make sure department no 1 is exist!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return result;
				}
				else
				{
					mPDept = ReflectionHelper.GetPrimitiveValue<int>(mReturn);
				}

				mReturn = false; // check whether user has mapped Parent_Department_Name or not
				int tempForEndVar = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("Parent_Department_Name").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturn))
				{ //if user has mapped l_group_name
					mysql = "select * from sysobjects where name = 'tmpDept'";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					SqlDataAdapter TempAdapter = null;
					TempAdapter = new SqlDataAdapter();
					TempAdapter.SelectCommand = TempCommand;
					DataSet TempDataset = null;
					TempDataset = new DataSet();
					TempAdapter.Fill(TempDataset);
					rs = TempDataset;

					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = "drop table tmpDept";
						TempCommand_2.ExecuteNonQuery();
					}
					rs = null;

					mysql = " select distinct g.Parent_Department_Name , g.a_parent_department_name into tmpDept from #tmpTable g";
					mysql = mysql + " Where g.Parent_Department_Name not in (select l_dept_name from pay_department) and g.Parent_Department_Name Is Not Null and g.Parent_Department_Name <> ''";
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					mysql = "select * from syscolumns where id = (select id from sysobjects where name = 'tmpDept') and name = 'dept_no'";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					SqlDataAdapter TempAdapter_4 = null;
					TempAdapter_4 = new SqlDataAdapter();
					TempAdapter_4.SelectCommand = TempCommand_4;
					DataSet TempDataset_4 = null;
					TempDataset_4 = new DataSet();
					TempAdapter_4.Fill(TempDataset_4);
					rs = TempDataset_4;

					if (rs.Tables[0].Rows.Count <= 0)
					{
						mysql = "alter table tmpDept add dept_no int NOT NULL IDENTITY (1000, 1)";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}

					mysql = "insert into pay_department (m_dept_cd,dept_no,l_dept_name,a_dept_name,user_cd) ";
					mysql = mysql + " select " + mPDept.ToString() + " ,dept_no ,Parent_Department_Name , a_parent_department_name, 1 from tmpDept";
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();
				}
				///****************************** Parent Department End ***************************************/

				///*********************************************************************/
				//-----------------Import Data of Department ---------------------------
				///*********************************************************************/

				mReturn = false; // check whether user has mapped Department_Name or not
				int tempForEndVar2 = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar2; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("Department_Name").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturn))
				{ //if user has mapped Department_Name
					mysql = "select * from sysobjects where name = 'tmpDept'";

					SqlCommand TempCommand_7 = null;
					TempCommand_7 = SystemVariables.gConn.CreateCommand();
					TempCommand_7.CommandText = mysql;
					SqlDataAdapter TempAdapter_7 = null;
					TempAdapter_7 = new SqlDataAdapter();
					TempAdapter_7.SelectCommand = TempCommand_7;
					DataSet TempDataset_7 = null;
					TempDataset_7 = new DataSet();
					TempAdapter_7.Fill(TempDataset_7);
					rs = TempDataset_7;

					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_8 = null;
						TempCommand_8 = SystemVariables.gConn.CreateCommand();
						TempCommand_8.CommandText = "drop table tmpDept";
						TempCommand_8.ExecuteNonQuery();
					}
					rs = null;

					mReturn = false; // check whether user has mapped Dept_No or not
					int tempForEndVar3 = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar3; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("dept_no").ToUpper())
						{
							mReturn = true;
							break;
						}
					}
					if (ReflectionHelper.GetPrimitiveValue<bool>(mReturn))
					{
						mysql = " select distinct dept_no,Parent_Department_Name, Department_Name , a_department_name  into tmpDept from #tmpTable ";
						mysql = mysql + " Where dept_no not in (select dept_no from pay_department) and dept_no Is Not Null and dept_no <> ''";
					}
					else
					{
						mysql = " select distinct g.Parent_Department_Name, g.Department_Name , g.a_department_Name into tmpDept from #tmpTable g ";
						mysql = mysql + " Where g.department_Name not in (select l_dept_name from pay_department) and g.Department_Name Is Not Null and g.Department_Name <> ''";
					}
					SqlCommand TempCommand_9 = null;
					TempCommand_9 = SystemVariables.gConn.CreateCommand();
					TempCommand_9.CommandText = mysql;
					TempCommand_9.ExecuteNonQuery();

					mysql = "select * from syscolumns where id = (select id from sysobjects where name = 'tmpDept') and name = 'dept_no'";
					SqlCommand TempCommand_10 = null;
					TempCommand_10 = SystemVariables.gConn.CreateCommand();
					TempCommand_10.CommandText = mysql;
					SqlDataAdapter TempAdapter_10 = null;
					TempAdapter_10 = new SqlDataAdapter();
					TempAdapter_10.SelectCommand = TempCommand_10;
					DataSet TempDataset_10 = null;
					TempDataset_10 = new DataSet();
					TempAdapter_10.Fill(TempDataset_10);
					rs = TempDataset_10;

					if (rs.Tables[0].Rows.Count <= 0)
					{
						mysql = "alter table tmpDept add dept_no int NOT NULL IDENTITY (200, 1)";
						SqlCommand TempCommand_11 = null;
						TempCommand_11 = SystemVariables.gConn.CreateCommand();
						TempCommand_11.CommandText = mysql;
						TempCommand_11.ExecuteNonQuery();
					}

					mysql = "insert into pay_department (m_dept_cd,dept_no,l_dept_name,a_dept_name,user_cd) ";
					mysql = mysql + " select (select dept_cd from pay_department where l_dept_name = parent_department_name), dept_no ,Department_Name , a_department_name, 1 from tmpDept";
					SqlCommand TempCommand_12 = null;
					TempCommand_12 = SystemVariables.gConn.CreateCommand();
					TempCommand_12.CommandText = mysql;
					TempCommand_12.ExecuteNonQuery();
				}
				///****************************** Department  End ***************************************/
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

		private bool MigrateDesignation()
		{
			bool result = false;
			DataSet rs = null; // to migrate products data
			string mysql = "";
			try
			{
				int i = 0;
				bool mReturn = false;

				///*********************************************************************/
				//-----------------Import Data of Designation ---------------------------
				///*********************************************************************/

				mReturn = false; // check whether user has mapped Designation_Name or not
				int tempForEndVar = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("Designation_Name").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				if (mReturn)
				{ //if user has mapped Designation_Name
					mysql = "select * from sysobjects where name = 'tmpDesg'";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					SqlDataAdapter TempAdapter = null;
					TempAdapter = new SqlDataAdapter();
					TempAdapter.SelectCommand = TempCommand;
					DataSet TempDataset = null;
					TempDataset = new DataSet();
					TempAdapter.Fill(TempDataset);
					rs = TempDataset;

					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = "drop table tmpDesg";
						TempCommand_2.ExecuteNonQuery();
					}
					rs = null;

					mReturn = false; // check whether user has mapped desg_no or not
					int tempForEndVar2 = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar2; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("desg_no").ToUpper())
						{
							mReturn = true;
							break;
						}
					}
					if (mReturn)
					{
						mysql = " select distinct desg_no, Designation_Name , a_Designation_Name  into tmpDesg from #tmpTable ";
						mysql = mysql + " Where desg_no not in (select desg_no from Pay_Designation) and desg_no Is Not Null and desg_no <> ''";
					}
					else
					{
						mysql = " select distinct g.Designation_Name , g.a_Designation_Name into tmpDesg from #tmpTable g ";
						mysql = mysql + " Where g.Designation_Name not in (select l_desg_name from Pay_Designation) and g.Designation_Name Is Not Null and g.Designation_Name <> ''";
					}
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					mysql = "select * from syscolumns where id = (select id from sysobjects where name = 'tmpDesg') and name = 'desg_no'";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					SqlDataAdapter TempAdapter_4 = null;
					TempAdapter_4 = new SqlDataAdapter();
					TempAdapter_4.SelectCommand = TempCommand_4;
					DataSet TempDataset_4 = null;
					TempDataset_4 = new DataSet();
					TempAdapter_4.Fill(TempDataset_4);
					rs = TempDataset_4;

					if (rs.Tables[0].Rows.Count <= 0)
					{
						mysql = "alter table tmpDesg add desg_no int NOT NULL IDENTITY (100, 1)";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}

					mysql = "insert into Pay_Designation (desg_no,l_desg_name,a_desg_name,user_cd) ";
					mysql = mysql + " select desg_no ,Designation_Name , a_Designation_Name, 1 from tmpDesg";
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();
				}
				///****************************** Designation  End ***************************************/

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

		private bool MigrateBank()
		{
			bool result = false;
			DataSet rs = null; // to migrate products data
			string mysql = "";
			try
			{
				int i = 0;
				bool mReturn = false;

				///*********************************************************************/
				//-----------------Import Data of Bank ---------------------------
				///*********************************************************************/

				mReturn = false; // check whether user has mapped Bank_Name or not
				int tempForEndVar = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("Bank_Name").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				if (mReturn)
				{ //if user has mapped Bank_Name
					mysql = "select * from sysobjects where name = 'tmpBank'";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					SqlDataAdapter TempAdapter = null;
					TempAdapter = new SqlDataAdapter();
					TempAdapter.SelectCommand = TempCommand;
					DataSet TempDataset = null;
					TempDataset = new DataSet();
					TempAdapter.Fill(TempDataset);
					rs = TempDataset;

					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = "drop table tmpBank";
						TempCommand_2.ExecuteNonQuery();
					}
					rs = null;

					mReturn = false; // check whether user has mapped bank_no or not
					int tempForEndVar2 = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar2; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("bank_no").ToUpper())
						{
							mReturn = true;
							break;
						}
					}
					if (mReturn)
					{
						mysql = " select distinct bank_no, Bank_Name , a_Bank_Name  into tmpBank from #tmpTable ";
						mysql = mysql + " Where bank_no not in (select bank_no from bank) and bank_no Is Not Null and bank_no <> ''";
					}
					else
					{
						mysql = " select distinct g.Bank_Name , g.a_Bank_Name into tmpBank from #tmpTable g ";
						mysql = mysql + " Where g.Bank_Name not in (select l_bank_name from bank) and g.Bank_Name Is Not Null and g.Bank_Name <> ''";
					}
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					mysql = "select * from syscolumns where id = (select id from sysobjects where name = 'tmpBank') and name = 'bank_no'";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					SqlDataAdapter TempAdapter_4 = null;
					TempAdapter_4 = new SqlDataAdapter();
					TempAdapter_4.SelectCommand = TempCommand_4;
					DataSet TempDataset_4 = null;
					TempDataset_4 = new DataSet();
					TempAdapter_4.Fill(TempDataset_4);
					rs = TempDataset_4;

					if (rs.Tables[0].Rows.Count <= 0)
					{
						mysql = "alter table tmpBank add bank_no int NOT NULL IDENTITY (100, 1)";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}

					mysql = "insert into bank (bank_no,l_bank_name,a_bank_name,user_cd) ";
					mysql = mysql + " select bank_no ,Bank_Name , a_Bank_Name, 1 from tmpBank";
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();
				}
				///****************************** Bank  End ***************************************/

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

		private bool MigrateNationality()
		{
			bool result = false;
			DataSet rs = null; // to migrate products data
			string mysql = "";
			try
			{
				int i = 0;
				bool mReturn = false;

				///*********************************************************************/
				//-----------------Import Data of Nationality ---------------------------
				///*********************************************************************/

				mReturn = false; // check whether user has mapped Nationality_Name or not
				int tempForEndVar = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("Nationality_Name").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				if (mReturn)
				{ //if user has mapped Nationality_Name
					mysql = "select * from sysobjects where name = 'tmpNat'";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					SqlDataAdapter TempAdapter = null;
					TempAdapter = new SqlDataAdapter();
					TempAdapter.SelectCommand = TempCommand;
					DataSet TempDataset = null;
					TempDataset = new DataSet();
					TempAdapter.Fill(TempDataset);
					rs = TempDataset;

					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = "drop table tmpNat";
						TempCommand_2.ExecuteNonQuery();
					}
					rs = null;

					mReturn = false; // check whether user has mapped nat_no or not
					int tempForEndVar2 = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar2; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("nat_no").ToUpper())
						{
							mReturn = true;
							break;
						}
					}
					if (mReturn)
					{
						mysql = " select distinct nat_no, Nationality_Name , a_Nationality_Name  into tmpNat from #tmpTable ";
						mysql = mysql + " Where nat_no not in (select nat_no from Pay_Nationality) and nat_no Is Not Null and nat_no <> ''";
					}
					else
					{
						mysql = " select distinct g.Nationality_Name , g.a_Nationality_Name into tmpNat from #tmpTable g ";
						mysql = mysql + " Where g.Nationality_Name not in (select l_Nationality_Name from Pay_Nationality) and g.Nationality_Name Is Not Null and g.Nationality_Name <> ''";
					}
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					mysql = "select * from syscolumns where id = (select id from sysobjects where name = 'tmpNat') and name = 'nat_no'";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					SqlDataAdapter TempAdapter_4 = null;
					TempAdapter_4 = new SqlDataAdapter();
					TempAdapter_4.SelectCommand = TempCommand_4;
					DataSet TempDataset_4 = null;
					TempDataset_4 = new DataSet();
					TempAdapter_4.Fill(TempDataset_4);
					rs = TempDataset_4;

					if (rs.Tables[0].Rows.Count <= 0)
					{
						mysql = "alter table tmpNat add nat_no int NOT NULL IDENTITY (100, 1)";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}

					mysql = "insert into Pay_Nationality(nat_no,l_Nat_Name,a_Nat_Name,user_cd) ";
					mysql = mysql + " select nat_no ,Nationality_Name , a_Nationality_Name, 1 from tmpNat";
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();
				}
				///****************************** Nationality  End ***************************************/

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

		private bool MigrateQualification()
		{
			bool result = false;
			DataSet rs = null; // to migrate products data
			string mysql = "";
			try
			{
				int i = 0;
				bool mReturn = false;

				///*********************************************************************/
				//-----------------Import Data of Qualification ---------------------------
				///*********************************************************************/

				mReturn = false; // check whether user has mapped qualification_name or not
				int tempForEndVar = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("qualification_name").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				if (mReturn)
				{ //if user has mapped qualification_name
					mysql = "select * from sysobjects where name = 'tmpqalfn'";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					SqlDataAdapter TempAdapter = null;
					TempAdapter = new SqlDataAdapter();
					TempAdapter.SelectCommand = TempCommand;
					DataSet TempDataset = null;
					TempDataset = new DataSet();
					TempAdapter.Fill(TempDataset);
					rs = TempDataset;

					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = "drop table tmpqalfn";
						TempCommand_2.ExecuteNonQuery();
					}
					rs = null;

					mReturn = false; // check whether user has mapped qalfn_no or not
					int tempForEndVar2 = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar2; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("qalfn_no").ToUpper())
						{
							mReturn = true;
							break;
						}
					}
					if (mReturn)
					{
						mysql = " select distinct qalfn_no, qualification_name , a_qualification_name  into tmpqalfn from #tmpTable ";
						mysql = mysql + " Where qalfn_no not in (select qalfn_no from Pay_Qualification) and qalfn_no Is Not Null and qalfn_no <> ''";
					}
					else
					{
						mysql = " select distinct g.qualification_name , g.a_qualification_name into tmpqalfn from #tmpTable g ";
						mysql = mysql + " Where g.qualification_name not in (select l_qalfn_name from Pay_Qualification) and g.qualification_name Is Not Null and g.qualification_name <> ''";
					}
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					mysql = "select * from syscolumns where id = (select id from sysobjects where name = 'tmpqalfn') and name = 'qalfn_no'";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					SqlDataAdapter TempAdapter_4 = null;
					TempAdapter_4 = new SqlDataAdapter();
					TempAdapter_4.SelectCommand = TempCommand_4;
					DataSet TempDataset_4 = null;
					TempDataset_4 = new DataSet();
					TempAdapter_4.Fill(TempDataset_4);
					rs = TempDataset_4;

					if (rs.Tables[0].Rows.Count <= 0)
					{
						mysql = "alter table tmpqalfn add qalfn_no int NOT NULL IDENTITY (100, 1)";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}

					mysql = "insert into Pay_Qualification(qalfn_no,l_qalfn_name,a_qalfn_name,user_cd) ";
					mysql = mysql + " select qalfn_no ,qualification_name , a_qualification_name, 1 from tmpqalfn";
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();
				}
				///****************************** Qualification  End ***************************************/

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

		private bool MigrateReligion()
		{
			bool result = false;
			DataSet rs = null; // to migrate products data
			string mysql = "";
			try
			{
				int i = 0;
				bool mReturn = false;

				///*********************************************************************/
				//-----------------Import Data of Religion ---------------------------
				///*********************************************************************/

				mReturn = false; // check whether user has mapped religion_name or not
				int tempForEndVar = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("religion_name").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				if (mReturn)
				{ //if user has mapped religion_name
					mysql = "select * from sysobjects where name = 'tmpreligion'";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					SqlDataAdapter TempAdapter = null;
					TempAdapter = new SqlDataAdapter();
					TempAdapter.SelectCommand = TempCommand;
					DataSet TempDataset = null;
					TempDataset = new DataSet();
					TempAdapter.Fill(TempDataset);
					rs = TempDataset;

					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = "drop table tmpreligion";
						TempCommand_2.ExecuteNonQuery();
					}
					rs = null;

					mReturn = false; // check whether user has mapped religion_no or not
					int tempForEndVar2 = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar2; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("religion_no").ToUpper())
						{
							mReturn = true;
							break;
						}
					}
					if (mReturn)
					{
						mysql = " select distinct religion_no, religion_name , a_religion_name  into tmpreligion from #tmpTable ";
						mysql = mysql + " Where religion_no not in (select religion_no from pay_religion) and religion_no Is Not Null and religion_no <> ''";
					}
					else
					{
						mysql = " select distinct g.religion_name , g.a_religion_name into tmpreligion from #tmpTable g ";
						mysql = mysql + " Where g.religion_name not in (select l_religion_name from pay_religion) and g.religion_name Is Not Null and g.religion_name <> ''";
					}
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					mysql = "select * from syscolumns where id = (select id from sysobjects where name = 'tmpreligion') and name = 'religion_no'";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					SqlDataAdapter TempAdapter_4 = null;
					TempAdapter_4 = new SqlDataAdapter();
					TempAdapter_4.SelectCommand = TempCommand_4;
					DataSet TempDataset_4 = null;
					TempDataset_4 = new DataSet();
					TempAdapter_4.Fill(TempDataset_4);
					rs = TempDataset_4;

					if (rs.Tables[0].Rows.Count <= 0)
					{
						mysql = "alter table tmpreligion add religion_no int NOT NULL IDENTITY (100, 1)";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}

					mysql = "insert into pay_religion(religion_no,l_religion_name,a_religion_name,user_cd) ";
					mysql = mysql + " select religion_no ,religion_name , a_religion_name, 1 from tmpreligion";
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();
				}
				///****************************** Religion  End ***************************************/

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

		private bool MigrateSponsor()
		{
			bool result = false;
			DataSet rs = null; // to migrate products data
			string mysql = "";
			try
			{
				int i = 0;
				bool mReturn = false;

				///*********************************************************************/
				//-----------------Import Data of Sponsor ---------------------------
				///*********************************************************************/

				mReturn = false; // check whether user has mapped l_first_name or not
				int tempForEndVar = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("l_first_name").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				if (mReturn)
				{ //if user has mapped l_first_name
					mysql = "select * from sysobjects where name = 'tmpsponsor'";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					SqlDataAdapter TempAdapter = null;
					TempAdapter = new SqlDataAdapter();
					TempAdapter.SelectCommand = TempCommand;
					DataSet TempDataset = null;
					TempDataset = new DataSet();
					TempAdapter.Fill(TempDataset);
					rs = TempDataset;

					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = "drop table tmpsponsor";
						TempCommand_2.ExecuteNonQuery();
					}
					rs = null;

					mReturn = false; // check whether user has mapped sponsor_no or not
					int tempForEndVar2 = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar2; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("sponsor_no").ToUpper())
						{
							mReturn = true;
							break;
						}
					}
					if (mReturn)
					{
						mysql = " select distinct sponsor_no, l_first_name, l_second_name, l_third_name, l_fourth_name, a_first_name, a_second_name  ";
						mysql = mysql + " , a_third_name, a_fourth_name, civil_id, comments into tmpsponsor from #tmpTable ";
						mysql = mysql + " Where sponsor_no not in (select sponsor_no from Pay_Sponsor) and sponsor_no Is Not Null and sponsor_no <> ''";
					}
					else
					{
						mysql = " select distinct  g.l_first_name, g.l_second_name, g.l_third_name, g.l_fourth_name, g.a_first_name, g.a_second_name";
						mysql = mysql + " , g.a_third_name, g.a_fourth_name, g.civil_id, , g.comments into tmpsponsor from #tmpTable g";
						mysql = mysql + " Where g.l_first_name not in (select l_first_name from Pay_Sponsor) and g.l_first_name Is Not Null and g.l_first_name <> ''";
					}
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					mysql = "select * from syscolumns where id = (select id from sysobjects where name = 'tmpsponsor') and name = 'sponsor_no'";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					SqlDataAdapter TempAdapter_4 = null;
					TempAdapter_4 = new SqlDataAdapter();
					TempAdapter_4.SelectCommand = TempCommand_4;
					DataSet TempDataset_4 = null;
					TempDataset_4 = new DataSet();
					TempAdapter_4.Fill(TempDataset_4);
					rs = TempDataset_4;

					if (rs.Tables[0].Rows.Count <= 0)
					{
						mysql = "alter table tmpsponsor add sponsor_no int NOT NULL IDENTITY (1, 1)";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}

					mysql = "insert into Pay_Sponsor(nat_cd,comp_cd,governate_cd,sponsor_no,l_first_name,l_second_name,l_third_name,l_fourth_name,a_first_name";
					mysql = mysql + " ,a_second_name,a_third_name,a_fourth_name,civil_id_no,user_cd, comments) ";
					mysql = mysql + " select 6,1,1, sponsor_no ,l_first_name ,isnull(l_second_name,''),isnull(l_third_name,''),isnull(l_fourth_name,''),isnull(a_first_name,'')";
					mysql = mysql + " ,isnull(a_second_name,''),isnull(a_third_name,''),isnull(a_fourth_name,'') ,civil_id, 1,comments  from tmpsponsor";
					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql;
					TempCommand_6.ExecuteNonQuery();
				}
				///****************************** Sponsor  End ***************************************/

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

		private bool MigrateEmployee()
		{ // to migrate Employee data
			bool result = false;
			string mysql = "";
			try
			{
				int i = 0;
				bool mReturn = false;
				DataSet rs = null;
				int mMaxNo = 0;
				int mVSCode = 0;
				int Cnt = 0;

				mReturn = false;

				mReturn = false; // check whether user has mapped l_first_name or not
				int tempForEndVar = grdMigrate2.Cols.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("l_first_name").ToUpper())
					{
						mReturn = true;
						break;
					}
				}

				int Column_No = 0;
				int Basic_Column_no = 0;
				if (mReturn)
				{ //if user has mapped l_first_name
					mysql = "select * from sysobjects where name = 'tmpEmployee'";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					SqlDataAdapter TempAdapter = null;
					TempAdapter = new SqlDataAdapter();
					TempAdapter.SelectCommand = TempCommand;
					DataSet TempDataset = null;
					TempDataset = new DataSet();
					TempAdapter.Fill(TempDataset);
					rs = TempDataset;

					if (rs.Tables[0].Rows.Count > 0)
					{
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = "drop table tmpEmployee";
						TempCommand_2.ExecuteNonQuery();
					}
					rs = null;

					mReturn = false; // check whether user has mapped sponsor_no or not
					int tempForEndVar2 = grdMigrate2.Cols.Count - 1;
					for (i = 0; i <= tempForEndVar2; i++)
					{
						if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(0, i)).ToUpper() == ("emp_no").ToUpper())
						{
							mReturn = true;
							break;
						}
					}
					if (mReturn)
					{
						mysql = " select distinct emp_no, l_first_name ,basic_salary , date_of_joining, bank_no, bank_account_no ,sponsor_no";
						mysql = mysql + " , dept_no,desg_no,nat_no,Qualification_No,religion_no,sex_id,Marital_Status,emp_type,1 as Status_cd";
						//'Informative Field*************************
						if (IsFieldExist("leave_balance"))
						{
							mysql = mysql + " ,leave_balance";
						}
						if (IsFieldExist("Leave_Bal_As_On_Date"))
						{
							mysql = mysql + " ,Leave_Bal_As_On_Date";
						}
						if (IsFieldExist("l_second_name"))
						{
							mysql = mysql + " ,l_second_name";
						}
						if (IsFieldExist("l_third_name"))
						{
							mysql = mysql + " ,l_third_name";
						}
						if (IsFieldExist("l_fourth_name"))
						{
							mysql = mysql + " ,l_fourth_name";
						}
						if (IsFieldExist("a_first_name"))
						{
							mysql = mysql + " ,a_first_name";
						}
						if (IsFieldExist("a_second_name"))
						{
							mysql = mysql + " ,a_second_name";
						}
						if (IsFieldExist("a_third_name"))
						{
							mysql = mysql + " ,a_third_name";
						}
						if (IsFieldExist("a_fourth_name"))
						{
							mysql = mysql + " ,a_fourth_name";
						}
						if (IsFieldExist("date_of_birth"))
						{
							mysql = mysql + " ,date_of_birth";
						}
						if (IsFieldExist("place_of_birth"))
						{
							mysql = mysql + " ,place_of_birth";
						}
						if (IsFieldExist("l_father_name"))
						{
							mysql = mysql + " ,l_father_name";
						}
						if (IsFieldExist("a_father_name"))
						{
							mysql = mysql + " ,a_father_name";
						}
						if (IsFieldExist("l_mother_name"))
						{
							mysql = mysql + " ,l_mother_name";
						}
						if (IsFieldExist("a_mother_name"))
						{
							mysql = mysql + " ,a_mother_name";
						}
						if (IsFieldExist("blood_group"))
						{
							mysql = mysql + " ,blood_group";
						}
						if (IsFieldExist("no_of_wives"))
						{
							mysql = mysql + " ,no_of_wives";
						}
						if (IsFieldExist("no_of_child"))
						{
							mysql = mysql + " ,no_of_child";
						}
						if (IsFieldExist("area"))
						{
							mysql = mysql + " ,area";
						}
						if (IsFieldExist("block"))
						{
							mysql = mysql + " ,block";
						}
						if (IsFieldExist("street"))
						{
							mysql = mysql + " ,street";
						}
						if (IsFieldExist("type_of_building"))
						{
							mysql = mysql + " ,type_of_building";
						}
						if (IsFieldExist("flat_no"))
						{
							mysql = mysql + " ,flat_no";
						}
						if (IsFieldExist("floor"))
						{
							mysql = mysql + " ,floor";
						}
						if (IsFieldExist("entrance"))
						{
							mysql = mysql + " ,entrance";
						}
						if (IsFieldExist("Permanent_Phone"))
						{
							mysql = mysql + " ,Permanent_Phone";
						}
						if (IsFieldExist("lane"))
						{
							mysql = mysql + " ,lane";
						}
						if (IsFieldExist("building_no"))
						{
							mysql = mysql + " ,building_no";
						}
						if (IsFieldExist("qasima"))
						{
							mysql = mysql + " ,qasima";
						}
						if (IsFieldExist("po_box"))
						{
							mysql = mysql + " ,po_box";
						}
						if (IsFieldExist("zip_cd"))
						{
							mysql = mysql + " ,zip_cd";
						}
						if (IsFieldExist("phone"))
						{
							mysql = mysql + " ,phone";
						}
						if (IsFieldExist("fax"))
						{
							mysql = mysql + " ,fax";
						}
						if (IsFieldExist("email"))
						{
							mysql = mysql + " ,email";
						}
						if (IsFieldExist("pager"))
						{
							mysql = mysql + " ,pager";
						}
						if (IsFieldExist("mobile"))
						{
							mysql = mysql + " ,mobile";
						}
						if (IsFieldExist("permanent_addr_1"))
						{
							mysql = mysql + " ,permanent_addr_1";
						}
						if (IsFieldExist("permanent_addr_2"))
						{
							mysql = mysql + " ,permanent_addr_2";
						}
						if (IsFieldExist("permanent_addr_3"))
						{
							mysql = mysql + " ,permanent_addr_3";
						}
						if (IsFieldExist("permanent_addr_4"))
						{
							mysql = mysql + " ,permanent_addr_4";
						}
						if (IsFieldExist("visa_no"))
						{
							mysql = mysql + " ,visa_no";
						}
						if (IsFieldExist("is_payroll_emp"))
						{
							mysql = mysql + " ,is_payroll_emp";
						}
						//'''(END Of Informative Field)**************
						//mySQL = mySQL & " , civil_id,civil_id_expiry_date,passport_no,passport_expiry_date"
						mysql = mysql + " into tmpEmployee from #tmpTable ";
						mysql = mysql + " Where emp_no not in (select emp_no from pay_employee) and emp_no Is Not Null and emp_no <> ''";
					}
					else
					{
						MessageBox.Show("Please Check Employee No !!!", "Employee Migrate", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}

					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					// ,department_name,designation_name,nationality_name,qualification_name,religion_name,bank_name,sponsor_name,sex_id,marital_status_id
					mysql = "  insert into pay_employee ( emp_no, l_first_name ,basic_salary,date_of_joining,bank_account_no";
					mysql = mysql + " , l_second_name, l_third_name, l_fourth_name";
					mysql = mysql + " ,a_first_name, a_second_name, a_third_name, a_fourth_name";
					mysql = mysql + " ,date_of_birth,place_of_birth,l_father_name,a_father_name,l_mother_name,a_mother_name";
					mysql = mysql + " ,blood_group,no_of_wives,no_of_child,area,block,street,type_of_building,floor,flat_no,entrance,Permanent_Phone,lane,building_no";
					mysql = mysql + " ,qasima,po_box,zip_cd,phone,fax,email,pager,mobile,permanent_addr_1,permanent_addr_2,permanent_addr_3,permanent_addr_4,visa_no";
					mysql = mysql + " ,civil_id,passport_no";
					mysql = mysql + " ,dept_cd,desg_cd,nat_cd,Qalfn_Cd,Religion_Cd,bank_cd,sponsor_cd,grade_cd,Comp_cd";
					mysql = mysql + " ,sex_id,marital_status_id,emp_type_id,is_payroll_emp,user_cd,Rate_Calc_Method_Id,location_cd,Status_cd ";
					mysql = mysql + " )";
					mysql = mysql + " select  emp_no, l_first_name ,basic_salary ,date_of_joining,bank_account_no";
					//''(Informative Field) ****************************************
					if (IsFieldExist("l_second_name"))
					{
						mysql = mysql + " ,l_second_name";
					}
					else
					{
						mysql = mysql + " ,''";
					}
					if (IsFieldExist("l_third_name"))
					{
						mysql = mysql + " ,l_third_name";
					}
					else
					{
						mysql = mysql + " ,''";
					}
					if (IsFieldExist("l_fourth_name"))
					{
						mysql = mysql + " ,l_fourth_name";
					}
					else
					{
						mysql = mysql + " ,''";
					}
					if (IsFieldExist("a_first_name"))
					{
						mysql = mysql + " ,a_first_name";
					}
					else
					{
						mysql = mysql + " ,''";
					}
					if (IsFieldExist("a_second_name"))
					{
						mysql = mysql + " ,a_second_name";
					}
					else
					{
						mysql = mysql + " ,''";
					}
					if (IsFieldExist("a_third_name"))
					{
						mysql = mysql + " ,a_third_name";
					}
					else
					{
						mysql = mysql + " ,''";
					}
					if (IsFieldExist("a_fourth_name"))
					{
						mysql = mysql + " ,a_fourth_name";
					}
					else
					{
						mysql = mysql + " ,''";
					}

					if (IsFieldExist("date_of_birth"))
					{
						mysql = mysql + " ,date_of_birth";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("place_of_birth"))
					{
						mysql = mysql + " ,place_of_birth";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("l_father_name"))
					{
						mysql = mysql + " ,l_father_name";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("a_father_name"))
					{
						mysql = mysql + " ,a_father_name";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("l_mother_name"))
					{
						mysql = mysql + " ,l_mother_name";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("a_mother_name"))
					{
						mysql = mysql + " ,a_mother_name";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("blood_group"))
					{
						mysql = mysql + " ,blood_group";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("no_of_wives"))
					{
						mysql = mysql + " ,no_of_wives";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("no_of_child"))
					{
						mysql = mysql + " ,no_of_child";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("area"))
					{
						mysql = mysql + " ,area";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("block"))
					{
						mysql = mysql + " ,block";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("street"))
					{
						mysql = mysql + " ,street";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("type_of_building"))
					{
						mysql = mysql + " ,type_of_building";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("floor"))
					{
						mysql = mysql + " ,floor";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("flat_no"))
					{
						mysql = mysql + " ,flat_no";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("entrance"))
					{
						mysql = mysql + " ,entrance";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("Permanent_Phone"))
					{
						mysql = mysql + " ,Permanent_Phone";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("lane"))
					{
						mysql = mysql + " ,lane";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("building_no"))
					{
						mysql = mysql + " ,building_no";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("qasima"))
					{
						mysql = mysql + " ,qasima";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("po_box"))
					{
						mysql = mysql + " ,po_box";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("zip_cd"))
					{
						mysql = mysql + " ,zip_cd";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("phone"))
					{
						mysql = mysql + " ,phone";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("fax"))
					{
						mysql = mysql + " ,fax";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("email"))
					{
						mysql = mysql + " ,email";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("pager"))
					{
						mysql = mysql + " ,pager";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("mobile"))
					{
						mysql = mysql + " ,mobile";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("permanent_addr_1"))
					{
						mysql = mysql + " ,permanent_addr_1";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("permanent_addr_2"))
					{
						mysql = mysql + " ,permanent_addr_2";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("permanent_addr_3"))
					{
						mysql = mysql + " ,permanent_addr_3";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("permanent_addr_4"))
					{
						mysql = mysql + " ,permanent_addr_4";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					if (IsFieldExist("visa_no"))
					{
						mysql = mysql + " ,visa_no";
					}
					else
					{
						mysql = mysql + " ,null";
					}
					//''Compalsory Field*****************************************************************
					mysql = mysql + " ,civil_id,passport_no";
					if (IsFieldExist("dept_no"))
					{
						mysql = mysql + " , isnull( (select dept_cd from pay_department pdept where pdept.dept_no = tmp.dept_no) , 1)  as dept_cd";
					}
					else
					{
						mysql = mysql + " , 1 ";
					}

					if (IsFieldExist("desg_no"))
					{
						mysql = mysql + " , isnull((select desg_cd from pay_designation pdesg where pdesg.desg_no = tmp.desg_no), 1) as desg_cd ";
					}
					else
					{
						mysql = mysql + " , 1 ";
					}

					if (IsFieldExist("nat_no"))
					{
						mysql = mysql + " , isnull((select nat_cd from pay_nationality pnat where pnat.nat_no = tmp.nat_no), 1) as nat_cd ";
					}
					else
					{
						mysql = mysql + " , 1 as nat_cd ";
					}

					if (IsFieldExist("qualification_no"))
					{
						mysql = mysql + " , isnull((select qalfn_cd from pay_qualification where qalfn_no = qualification_no), null) as qalfn_cd ";
					}
					else
					{
						mysql = mysql + " , null";
					}

					if (IsFieldExist("religion_no"))
					{
						mysql = mysql + " , (select religion_cd from pay_religion pr where pr.religion_no = tmp.religion_no) as religion_cd ";
					}
					else
					{
						mysql = mysql + " ,1  religion_cd";
					}
					if (IsFieldExist("bank_no"))
					{
						mysql = mysql + " , (select bank_cd from bank b where b.bank_no = tmp.bank_no) as bank_cd ";
					}
					else
					{
						mysql = mysql + " ,null ";
					}
					if (IsFieldExist("sponsor_no"))
					{
						mysql = mysql + " , (select sponsor_cd from pay_sponsor pspon where pspon.sponsor_no = tmp.sponsor_no) as sponsor_cd ";
					}
					else
					{
						mysql = mysql + " ,1 ";
					}
					mysql = mysql + " , (select grade_cd from pay_grade where grade_no = 1) as grade_cd";
					mysql = mysql + " , 1";

					if (IsFieldExist("sex_id"))
					{
						mysql = mysql + " , (case when sex_id = 'Male' then 8  else 9 end )";
					}
					else
					{
						mysql = mysql + " ,8";
					}

					if (IsFieldExist("Marital_Status"))
					{
						mysql = mysql + " , (case when Marital_Status = 'Married' then 12  when Marital_Status = 'Widow' then 13 else 11 end )";
					}
					else
					{
						mysql = mysql + " ,11 ";
					}
					if (IsFieldExist("emp_type"))
					{
						mysql = mysql + " , (case when emp_type = 'T' then 147 when emp_type = 'L' then 146 when emp_type = 'S' then 145 else 14 end )";
					}
					else
					{
						mysql = mysql + " ,null ";
					}
					if (IsFieldExist("is_Payroll_emp"))
					{
						mysql = mysql + " , (case when is_Payroll_emp = 'No' then 0  else 1 end )";
					}
					else
					{
						mysql = mysql + " ,1 ";
					}
					//user code
					mysql = mysql + " ,  1,60,Null, 1 ";
					mysql = mysql + " from #tmpTable tmp ";
					mysql = mysql + " Where emp_no Is Not Null ";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

					//'''Update Payroll and Employee Indeminity Setting
					mysql = " update pay_employee";
					mysql = mysql + " set allow_overtime = 0 , is_payroll_emp = 1";
					mysql = mysql + " , rate_calc_method_id = case emp_type_id when 147 then 130 else " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("rate_calc_method")) + " end ";
					mysql = mysql + " , payment_type_id = 25";
					mysql = mysql + " , weekend = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("weekend"));
					mysql = mysql + " , weekend_day1_id = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("weekend_day1"));
					mysql = mysql + " , weekend_day2_id = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("weekend_day2"));
					mysql = mysql + " , days_per_month = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("days_per_month"));
					mysql = mysql + " , hours_per_day = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("hours_per_day"));
					mysql = mysql + " , indemnity_switch_over_period = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("indemnity_switch_over_period"));
					mysql = mysql + " , indemnity_days_before_sop = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("indemnity_days_before_sop"));
					mysql = mysql + " , indemnity_days_after_sop = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("indemnity_days_after_sop"));
					mysql = mysql + " , indemnity_working_days_per_month_before_sop = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("wd_per_month_before_sop"));
					mysql = mysql + " , indemnity_working_days_per_month_after_sop = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("wd_per_month_after_sop"));
					mysql = mysql + " , indemnity_deduct_paid_days = " + ((ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("deduct_paid_days"))) ? 1 : 0).ToString();
					mysql = mysql + " , indemnity_deduct_unpaid_days = " + ((ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("deduct_unpaid_days"))) ? 1 : 0).ToString();
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();

					//''''Insert Billing Master************************
					if (IsFieldExist("Allowance1"))
					{
						mysql = " insert into pay_billing_type(bill_no,l_bill_name,bill_type_id,user_cd)";
						mysql = mysql + " values(101,'Allowance 1',51,1)";
						SqlCommand TempCommand_6 = null;
						TempCommand_6 = SystemVariables.gConn.CreateCommand();
						TempCommand_6.CommandText = mysql;
						TempCommand_6.ExecuteNonQuery();
					}
					if (IsFieldExist("Allowance2"))
					{
						mysql = " insert into pay_billing_type(bill_no,l_bill_name,bill_type_id,user_cd)";
						mysql = mysql + " values(102,'Allowance 2',51,1)";
						SqlCommand TempCommand_7 = null;
						TempCommand_7 = SystemVariables.gConn.CreateCommand();
						TempCommand_7.CommandText = mysql;
						TempCommand_7.ExecuteNonQuery();
					}
					if (IsFieldExist("Allowance3"))
					{
						mysql = " insert into pay_billing_type(bill_no,l_bill_name,bill_type_id,user_cd)";
						mysql = mysql + " values(103,'Allowance 3',51,1)";
						SqlCommand TempCommand_8 = null;
						TempCommand_8 = SystemVariables.gConn.CreateCommand();
						TempCommand_8.CommandText = mysql;
						TempCommand_8.ExecuteNonQuery();
					}
					if (IsFieldExist("Allowance4"))
					{
						mysql = " insert into pay_billing_type(bill_no,l_bill_name,bill_type_id,user_cd)";
						mysql = mysql + " values(104,'Allowance 4',51,1)";
						SqlCommand TempCommand_9 = null;
						TempCommand_9 = SystemVariables.gConn.CreateCommand();
						TempCommand_9.CommandText = mysql;
						TempCommand_9.ExecuteNonQuery();
					}
					if (IsFieldExist("Allowance5"))
					{
						mysql = " insert into pay_billing_type(bill_no,l_bill_name,bill_type_id,user_cd)";
						mysql = mysql + " values(105,'Allowance 5',51,1)";
						SqlCommand TempCommand_10 = null;
						TempCommand_10 = SystemVariables.gConn.CreateCommand();
						TempCommand_10.CommandText = mysql;
						TempCommand_10.ExecuteNonQuery();
					}
					if (IsFieldExist("Allowance6"))
					{
						mysql = " insert into pay_billing_type(bill_no,l_bill_name,bill_type_id,user_cd)";
						mysql = mysql + " values(106,'Allowance 6',51,1)";
						SqlCommand TempCommand_11 = null;
						TempCommand_11 = SystemVariables.gConn.CreateCommand();
						TempCommand_11.CommandText = mysql;
						TempCommand_11.ExecuteNonQuery();
					}
					if (IsFieldExist("Allowance7"))
					{
						mysql = " insert into pay_billing_type(bill_no,l_bill_name,bill_type_id,user_cd)";
						mysql = mysql + " values(107,'Allowance 7',51,1)";
						SqlCommand TempCommand_12 = null;
						TempCommand_12 = SystemVariables.gConn.CreateCommand();
						TempCommand_12.CommandText = mysql;
						TempCommand_12.ExecuteNonQuery();
					}
					if (IsFieldExist("Allowance8"))
					{
						mysql = " insert into pay_billing_type(bill_no,l_bill_name,bill_type_id,user_cd)";
						mysql = mysql + " values(108,'Allowance 8',51,1)";
						SqlCommand TempCommand_13 = null;
						TempCommand_13 = SystemVariables.gConn.CreateCommand();
						TempCommand_13.CommandText = mysql;
						TempCommand_13.ExecuteNonQuery();
					}
					if (IsFieldExist("Allowance9"))
					{
						mysql = " insert into pay_billing_type(bill_no,l_bill_name,bill_type_id,user_cd)";
						mysql = mysql + " values(109,'Allowance 9',51,1)";
						SqlCommand TempCommand_14 = null;
						TempCommand_14 = SystemVariables.gConn.CreateCommand();
						TempCommand_14.CommandText = mysql;
						TempCommand_14.ExecuteNonQuery();
					}
					if (IsFieldExist("Allowance10"))
					{
						mysql = " insert into pay_billing_type(bill_no,l_bill_name,bill_type_id,user_cd)";
						mysql = mysql + " values(110,'Allowance 10',51,1)";
						SqlCommand TempCommand_15 = null;
						TempCommand_15 = SystemVariables.gConn.CreateCommand();
						TempCommand_15.CommandText = mysql;
						TempCommand_15.ExecuteNonQuery();
					}
					//'''' End of billing master data

					//'''' Migrate Employee Billing Migration
					int tempForEndVar3 = grdMigrate2.Rows.Count - 1;
					for (i = 1; i <= tempForEndVar3; i++)
					{
						if (IsFieldExist("Basic_Salary"))
						{
							Column_No = ColumnNo("Basic Salary");
							Basic_Column_no = ColumnNo("emp_type");
							if (!SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, Column_No), SystemVariables.DataType.NumberType))
							{
								if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, Basic_Column_no)).ToUpper() != "T")
								{
									mysql = "insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount,include_in_indemnity,user_cd)";
									mysql = mysql + " select (select emp_cd from pay_employee where emp_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + "') as emp_no";
									mysql = mysql + " , (select bill_cd from pay_billing_type where bill_no = 1) as bill_no";
									mysql = mysql + " , 'F' , " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, Column_No));
									mysql = mysql + " ,1,1";
									SqlCommand TempCommand_16 = null;
									TempCommand_16 = SystemVariables.gConn.CreateCommand();
									TempCommand_16.CommandText = mysql;
									TempCommand_16.ExecuteNonQuery();
								}
								else
								{
									mysql = " update pay_employee";
									mysql = mysql + " set rate_per_hour = case emp_type_id when 147 then " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, Column_No)) + " else 0 end ";
									mysql = mysql + " , rate_per_day = case emp_type_id when 147 then " + ((ReflectionHelper.GetPrimitiveValue<double>(grdMigrate2.getCellText(i, Column_No)) * 8).ToString()) + " else 0 end ";
									mysql = mysql + " where emp_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + "'";
									SqlCommand TempCommand_17 = null;
									TempCommand_17 = SystemVariables.gConn.CreateCommand();
									TempCommand_17.CommandText = mysql;
									TempCommand_17.ExecuteNonQuery();
								}
							}
						}
						if (IsFieldExist("Allowance1"))
						{
							Column_No = ColumnNo("Allowance 1");
							if (!SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, Column_No), SystemVariables.DataType.NumberType))
							{
								mysql = "insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount,user_cd)";
								mysql = mysql + " select (select emp_cd from pay_employee where emp_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + "') as emp_no";
								mysql = mysql + " , (select bill_cd from pay_billing_type where bill_no = 101) as bill_no";
								mysql = mysql + " , 'F' , " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, Column_No));
								mysql = mysql + " ,1";
								SqlCommand TempCommand_18 = null;
								TempCommand_18 = SystemVariables.gConn.CreateCommand();
								TempCommand_18.CommandText = mysql;
								TempCommand_18.ExecuteNonQuery();
							}
						}
						if (IsFieldExist("Allowance2"))
						{
							Column_No = ColumnNo("Allowance 2");
							if (!SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, Column_No), SystemVariables.DataType.NumberType))
							{
								mysql = "insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount,user_cd)";
								mysql = mysql + " select (select emp_cd from pay_employee where emp_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + "') as emp_no";
								mysql = mysql + " , (select bill_cd from pay_billing_type where bill_no = 102) as bill_no";
								mysql = mysql + " , 'F' , " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, Column_No));
								mysql = mysql + " ,1";
								SqlCommand TempCommand_19 = null;
								TempCommand_19 = SystemVariables.gConn.CreateCommand();
								TempCommand_19.CommandText = mysql;
								TempCommand_19.ExecuteNonQuery();
							}
						}
						if (IsFieldExist("Allowance3"))
						{
							Column_No = ColumnNo("Allowance 3");
							if (!SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, Column_No), SystemVariables.DataType.NumberType))
							{
								mysql = "insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount,user_cd)";
								mysql = mysql + " select (select emp_cd from pay_employee where emp_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + "') as emp_no";
								mysql = mysql + " , (select bill_cd from pay_billing_type where bill_no = 103) as bill_no";
								mysql = mysql + " , 'F' , " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, Column_No));
								mysql = mysql + " ,1";
								SqlCommand TempCommand_20 = null;
								TempCommand_20 = SystemVariables.gConn.CreateCommand();
								TempCommand_20.CommandText = mysql;
								TempCommand_20.ExecuteNonQuery();
							}
						}
						if (IsFieldExist("Allowance4"))
						{
							Column_No = ColumnNo("Allowance 4");
							if (!SystemProcedure2.IsItEmpty(grdMigrate2.getCellText(i, Column_No), SystemVariables.DataType.NumberType))
							{
								mysql = "insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount,user_cd)";
								mysql = mysql + " select (select emp_cd from pay_employee where emp_no = '" + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, 1)) + "') as emp_no";
								mysql = mysql + " , (select bill_cd from pay_billing_type where bill_no = 104) as bill_no";
								mysql = mysql + " , 'F' , " + ReflectionHelper.GetPrimitiveValue<string>(grdMigrate2.getCellText(i, Column_No));
								mysql = mysql + ", 1";
								SqlCommand TempCommand_21 = null;
								TempCommand_21 = SystemVariables.gConn.CreateCommand();
								TempCommand_21.CommandText = mysql;
								TempCommand_21.ExecuteNonQuery();
							}
						}
						//'''        If IsFieldExist("Allowance5") = True Then
						//'''            Column_No = ColumnNo("Allowance 5")
						//'''            If IsItEmpty(grdMigrate2.Cell(flexcpText, i, Column_No), NumberType) = False Then
						//'''                mySql = "insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount,user_cd)"
						//'''                mySql = mySql & " select (select emp_cd from pay_employee where emp_no = " & grdMigrate2.Cell(flexcpText, i, 1) & ") as emp_no"
						//'''                mySql = mySql & " , (select bill_cd from pay_billing_type where bill_no = 105) as bill_no"
						//'''                mySql = mySql & " , 'F' , " & grdMigrate2.Cell(flexcpText, i, Column_No)
						//'''                mySql = mySql & ",1"
						//'''                gConn.Execute mySql
						//'''            End If
						//'''        End If
						//'''        If IsFieldExist("Allowance6") = True Then
						//'''            Column_No = ColumnNo("Allowance 6")
						//'''            If IsItEmpty(grdMigrate2.Cell(flexcpText, i, Column_No), NumberType) = False Then
						//'''                mySql = "insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount,user_cd)"
						//'''                mySql = mySql & " select (select emp_cd from pay_employee where emp_no = " & grdMigrate2.Cell(flexcpText, i, 1) & ") as emp_no"
						//'''                mySql = mySql & " , (select bill_cd from pay_billing_type where bill_no = 106) as bill_no"
						//'''                mySql = mySql & " , 'F' , " & grdMigrate2.Cell(flexcpText, i, Column_No)
						//'''                mySql = mySql & " ,1"
						//'''                gConn.Execute mySql
						//'''            End If
						//'''        End If
						//'''        If IsFieldExist("Allowance7") = True Then
						//'''            Column_No = ColumnNo("Allowance 7")
						//'''            If IsItEmpty(grdMigrate2.Cell(flexcpText, i, Column_No), NumberType) = False Then
						//'''                mySql = "insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount,user_cd)"
						//'''                mySql = mySql & " select (select emp_cd from pay_employee where emp_no = " & grdMigrate2.Cell(flexcpText, i, 1) & ") as emp_no"
						//'''                mySql = mySql & " , (select bill_cd from pay_billing_type where bill_no = 107) as bill_no"
						//'''                mySql = mySql & " , 'F' , " & grdMigrate2.Cell(flexcpText, i, Column_No)
						//'''                mySql = mySql & ",1"
						//'''                gConn.Execute mySql
						//'''            End If
						//'''        End If
						//'''        If IsFieldExist("Allowance8") = True Then
						//'''            Column_No = ColumnNo("Allowance 8")
						//'''            If IsItEmpty(grdMigrate2.Cell(flexcpText, i, Column_No), NumberType) = False Then
						//'''                mySql = "insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount,user_cd)"
						//'''                mySql = mySql & " select (select emp_cd from pay_employee where emp_no = " & grdMigrate2.Cell(flexcpText, i, 1) & ") as emp_no"
						//'''                mySql = mySql & " , (select bill_cd from pay_billing_type where bill_no = 108) as bill_no"
						//'''                mySql = mySql & " , 'F' , " & grdMigrate2.Cell(flexcpText, i, Column_No)
						//'''                mySql = mySql & ", 1"
						//'''                gConn.Execute mySql
						//'''        End If
						//'''        End If
						//'''        If IsFieldExist("Allowance9") = True Then
						//'''            Column_No = ColumnNo("Allowance 9")
						//'''            If IsItEmpty(grdMigrate2.Cell(flexcpText, i, Column_No), NumberType) = False Then
						//'''                mySql = "insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount,user_cd)"
						//'''                mySql = mySql & " select (select emp_cd from pay_employee where emp_no = " & grdMigrate2.Cell(flexcpText, i, 1) & ") as emp_no"
						//'''                mySql = mySql & " , (select bill_cd from pay_billing_type where bill_no = 109) as bill_no"
						//'''                mySql = mySql & " , 'F' , " & grdMigrate2.Cell(flexcpText, i, Column_No)
						//'''                mySql = mySql & " ,1"
						//'''                gConn.Execute mySql
						//'''            End If
						//'''        End If
						//'''        If IsFieldExist("Allowance10") = True Then
						//'''            Column_No = ColumnNo("Allowance 10")
						//'''            If IsItEmpty(grdMigrate2.Cell(flexcpText, i, Column_No), NumberType) = False Then
						//'''                mySql = "insert into pay_employee_billing_details(emp_cd,bill_cd,billing_mode,amount,user_cd)"
						//'''                mySql = mySql & " select (select emp_cd from pay_employee where emp_no = " & grdMigrate2.Cell(flexcpText, i, 1) & ") as emp_no"
						//'''                mySql = mySql & " , (select bill_cd from pay_billing_type where bill_no = 110) as bill_no"
						//'''                mySql = mySql & " , 'F' , " & grdMigrate2.Cell(flexcpText, i, Column_No)
						//'''                mySql = mySql & " ,1"
						//'''                gConn.Execute mySql
						//'''            End If
						//'''        End If
					}
				}
				// End of Migration of Employee Billing.**********************
				// Employee Document Migration Utility
				int mEntId = 0;
				object mReturnValue = null;

				if (IsFieldExist("civil_id_expiry_date") && IsFieldExist("civil_id"))
				{
					mysql = " insert into pay_document_master(document_no,l_document_name,a_document_name,document_type_cd";
					mysql = mysql + " ,notification_period,user_cd)";
					mysql = mysql + " values(2,'Civil ID','Civil ID',2,30,1)";
					SqlCommand TempCommand_22 = null;
					TempCommand_22 = SystemVariables.gConn.CreateCommand();
					TempCommand_22.CommandText = mysql;
					TempCommand_22.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mEntId = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Document Master For Civil Id is not created!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

					mysql = " insert into pay_document_detail(emp_cd,document_cd,document_no,[expiry_date],period,user_cd)";
					mysql = mysql + " select (select emp_cd from pay_employee pemp where pemp.emp_no = tmp.emp_no)";
					mysql = mysql + " ," + mEntId.ToString() + " , civil_id , civil_id_expiry_date , 30 , 1";
					mysql = mysql + " from #tmpTable tmp ";
					mysql = mysql + " Where emp_no Is Not Null and civil_id is not null and civil_id_expiry_date is not null  ";
					SqlCommand TempCommand_23 = null;
					TempCommand_23 = SystemVariables.gConn.CreateCommand();
					TempCommand_23.CommandText = mysql;
					TempCommand_23.ExecuteNonQuery();
				}

				if (IsFieldExist("passport_expiry_date") && IsFieldExist("passport_no"))
				{
					mysql = " insert into pay_document_master(document_no,l_document_name,a_document_name,document_type_cd";
					mysql = mysql + " ,notification_period,user_cd)";
					mysql = mysql + " values(1,'Passport No','Passport No',1,30,1)";
					SqlCommand TempCommand_24 = null;
					TempCommand_24 = SystemVariables.gConn.CreateCommand();
					TempCommand_24.CommandText = mysql;
					TempCommand_24.ExecuteNonQuery();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mEntId = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Document Master For Civil Id is not created!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

					mysql = " insert into pay_document_detail(emp_cd,document_cd,document_no,[expiry_date],period,user_cd)";
					mysql = mysql + " select (select emp_cd from pay_employee pemp where pemp.emp_no = tmp.emp_no)";
					mysql = mysql + " ," + mEntId.ToString() + " , Right(passport_no,20) , Passport_expiry_date , 30 , 1";
					mysql = mysql + " from #tmpTable tmp ";
					mysql = mysql + " Where emp_no Is Not Null and passport_no is not null and passport_expiry_date is not null  ";
					SqlCommand TempCommand_25 = null;
					TempCommand_25 = SystemVariables.gConn.CreateCommand();
					TempCommand_25.CommandText = mysql;
					TempCommand_25.ExecuteNonQuery();
				}
				//'''' End of Document Migration Utility

				//'''' Employee Leave Details
				//'insert Annual leave
				if (IsFieldExist("leave_balance"))
				{
					mysql = " insert into pay_employee_leave_details";
					mysql = mysql + " (emp_cd, leave_cd, leave_switch_over_period, leave_days_before_sop, leave_days_after_sop, working_days_per_month_before_sop,";
					mysql = mysql + " working_days_per_month_after_sop, deduct_paid_days, deduct_unpaid_days, user_cd)";
					mysql = mysql + " select";
					mysql = mysql + " ( select emp_cd from pay_employee";
					mysql = mysql + " where emp_no = tmpemp.emp_no )";
					mysql = mysql + " , 1";
					mysql = mysql + " , 5, 30, 30, 26, 26, 0, 1, 1";
					mysql = mysql + " from #tmpTable tmpemp";
					mysql = mysql + " Where tmpemp.emp_no Is Not Null";
					SqlCommand TempCommand_26 = null;
					TempCommand_26 = SystemVariables.gConn.CreateCommand();
					TempCommand_26.CommandText = mysql;
					TempCommand_26.ExecuteNonQuery();
				}
				//'insert sick leave
				mysql = "  insert into pay_employee_leave_details";
				mysql = mysql + " (emp_cd, leave_cd, leave_switch_over_period, leave_days_before_sop, leave_days_after_sop, working_days_per_month_before_sop,";
				mysql = mysql + " working_days_per_month_after_sop, deduct_paid_days, deduct_unpaid_days, user_cd)";
				mysql = mysql + " select";
				mysql = mysql + " ( select emp_cd from pay_employee";
				mysql = mysql + "   where emp_no = tmpemp.emp_no )";
				mysql = mysql + " , 3";
				mysql = mysql + " , 5, 75, 75, 30, 30, 0, 1, 1 ";
				mysql = mysql + " from #tmpTable tmpemp";
				mysql = mysql + " Where tmpemp.emp_no Is Not Null";
				SqlCommand TempCommand_27 = null;
				TempCommand_27 = SystemVariables.gConn.CreateCommand();
				TempCommand_27.CommandText = mysql;
				TempCommand_27.ExecuteNonQuery();

				if (IsFieldExist("leave_balance"))
				{
					mysql = " insert into pay_leave_accrual_summary";
					mysql = mysql + " (plas_emp_cd, plas_leave_cd, plas_year, plas_month, plas_curr_cd, plas_accrued_days, plas_cumm_accrued_days,";
					mysql = mysql + " plas_user_cd, plas_annual_leave_days)";
					mysql = mysql + " select";
					mysql = mysql + " ( select emp_cd from pay_employee";
					mysql = mysql + " where emp_no = tmpemp.emp_no )";
					mysql = mysql + " , 1";
					mysql = mysql + " ,year(tmpemp.Leave_Bal_As_On_Date) , month(tmpemp.Leave_Bal_As_On_Date), 1, isnull(tmpemp.leave_balance,0), isnull(tmpemp.leave_balance,0), 1, 30";
					mysql = mysql + " from #tmpTable tmpemp";
					mysql = mysql + " Where tmpemp.emp_no Is Not Null and leave_balance is not null ";
					SqlCommand TempCommand_28 = null;
					TempCommand_28 = SystemVariables.gConn.CreateCommand();
					TempCommand_28.CommandText = mysql;
					TempCommand_28.ExecuteNonQuery();
				}
				//'''' End Of Employee Leave Details

				//''''End of Data Migration
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

		private int ColumnNo(string pFieldName)
		{
			int i = 0;
			int tempForEndVar = grdMigrate2.Cols.Count - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				if (ReflectionHelper.GetPrimitiveValue<string>(grdMigrate1.getCellText(0, i)).ToUpper() == pFieldName.ToUpper())
				{
					return i;
				}
			}
			return 0;
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}