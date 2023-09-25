
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysSyncronize
		: System.Windows.Forms.Form
	{

		
		public frmSysSyncronize()
{
InitializeComponent();
} 
 public  void frmSysSyncronize_old()
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
		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private int mFormCallType = 0;

		private const int BIF_RETURNONLYFSDIRS = 1;
		private const int BIF_DONTGOBELOWDOMAIN = 2;
		private const int MAX_PATH = 260;

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis#2041
		////UPGRADE_TODO: (1050) Structure BrowseInfo may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis#1050
		//[DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int SHBrowseForFolder(ref InnovaUpdSupport.PInvoke.UnsafeNative.Structures.BrowseInfo lpbi);

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis#2041
		//[DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int SHGetPathFromIDList(int pidList, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpBuffer);

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis#2041
		//[DllImport("kernel32.dll", EntryPoint = "lstrcatA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int lstrcat([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString2);



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



		private void cmdExport_Click(Object eventSender, EventArgs eventArgs)
		{
			string DestinationFile = "";
			string SourceFile = "";
			try
			{

				if (!txtExportPath.Visible)
				{
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtExportPath.Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("dropbox_export_path"));
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(txtExportLocationCode.Text) || txtExportLocationCode.Text == "")
				{
					MessageBox.Show("Please Select Location", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtExportLocationCode.Focus();
					throw new Exception();
				}
				else if ((Convert.IsDBNull(txtExportPath) || txtExportPath.Text == "") && !ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_dropbox_syncronization")))
				{ 
					MessageBox.Show("Please Enter File Path", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtExportPath.Focus();
					throw new Exception();
				}
				else
				{
					DestinationFile = txtExportPath.Text + "\\" + txtExportDisplayLocation.Text + "-" + StringsHelper.Replace(StringsHelper.Replace(DateTimeHelper.ToString(DateTime.Today), "\\", "", 1, -1, CompareMethod.Binary), "-", "", 1, -1, CompareMethod.Binary) + ".exp"; // "-" & DateTime.Date & ".exp"
					SourceFile = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + "\\TempExport.mdb";

					File.Copy(SourceFile, DestinationFile, true); // Copy source to target.

					ExportData(DestinationFile);
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + excep.Message + " " + SourceFile + " " + DestinationFile, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private object ExportData(string dbPath)
		{
			SqlConnection conn = null;
			DataSet recTempRecord = null;
			StringBuilder mysql = new StringBuilder();
			string txnCodes = "";
			string locationCode = "";
			int mExportedRecord = 0;
			try
			{

				conn = new SqlConnection();

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txnCodes = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Sync_Export_Transaction_Types"));
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				locationCode = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where locat_no = " + txtExportLocationCode.Text));
				//conn.Open ("Provider=Microsoft.Jet.OLEDB 4.0;Data Source=C:\Program Files\Microsoft Office\Office\Samples\Northwind.mdb;Persist Security Info=False")
				conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + ";Persist Security Info=False";
				//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis#7010
				conn.Open();

				//-----------------------------------------Export Item Group-------------------------------------------------

				lblExportStatus.Caption = "Exporting Item Group";
				Application.DoEvents();

				mysql = new StringBuilder("select * from ICS_Item_Group where group_cd in");
				mysql.Append("(select group_cd from ICS_Item where prod_cd in");
				mysql.Append(" (select prod_cd from ICS_Transaction_Details dt inner join ICS_Transaction mt");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportFromDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportToDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + ")))");


				recTempRecord = new DataSet();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter = null;
				TempAdapter = new SqlDataAdapter();
				TempAdapter.SelectCommand = TempCommand;
				DataSet TempDataset = null;
				TempDataset = new DataSet();
				TempAdapter.Fill(TempDataset);
				recTempRecord = TempDataset;

				SqlCommand TempCommand_2 = null;
				TempCommand_2 = conn.CreateCommand();
				TempCommand_2.CommandText = "delete from ICS_Item_Group";
				TempCommand_2.ExecuteNonQuery();
				mExportedRecord = 0;
				foreach (DataRow iteration_row in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("insert into ICS_Item_Group (Group_Cd, M_Group_Cd, Group_No, L_Group_Name, A_Group_Name, Group_Level, Show,");
					mysql.Append(" Protected, Comments, User_Cd, User_Date_Time, row_id)");
					mysql.Append(" values ( " + Convert.ToString(iteration_row["Group_Cd"]) + "," + Convert.ToString(iteration_row["M_Group_Cd"]) + "," + Convert.ToString(iteration_row["Group_No"]) + ",");
					mysql.Append(" '" + Convert.ToString(iteration_row["L_Group_Name"]) + "', '" + Convert.ToString(iteration_row["A_Group_Name"]) + "',");
					mysql.Append(" " + Convert.ToString(iteration_row["Group_Level"]) + "," + Convert.ToString(iteration_row["Show"]) + ", ");
					mysql.Append(" " + Convert.ToString(iteration_row["Protected"]) + ", '" + Convert.ToString(iteration_row["Comments"]) + "', ");
					mysql.Append(" " + Convert.ToString(iteration_row["User_Cd"]) + ", '" + Convert.ToString(iteration_row["User_Date_Time"]) + "', '" + Convert.ToString(iteration_row["row_id"]) + "')");

					SqlCommand TempCommand_3 = null;
					TempCommand_3 = conn.CreateCommand();
					TempCommand_3.CommandText = mysql.ToString();
					TempCommand_3.ExecuteNonQuery();
					mExportedRecord++;
					ExportProgress.Value = Convert.ToInt32(((mExportedRecord + 1) / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);

				}
				recTempRecord = null;
				//-------------------------------------End Export Item Group-------------------------------------------------

				//--------------------------------------Export Item Category-------------------------------------------------
				lblExportStatus.Caption = "Exporting Item Category";
				Application.DoEvents();

				mysql = new StringBuilder("select * from ICS_Item_Category where Cat_Cd in");
				mysql.Append("(select Cat_Cd from ICS_Item where prod_cd in");
				mysql.Append(" (select prod_cd from ICS_Transaction_Details dt inner join ICS_Transaction mt");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportFromDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportToDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + ")))");

				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_4 = null;
				TempAdapter_4 = new SqlDataAdapter();
				TempAdapter_4.SelectCommand = TempCommand_4;
				DataSet TempDataset_4 = null;
				TempDataset_4 = new DataSet();
				TempAdapter_4.Fill(TempDataset_4);
				recTempRecord = TempDataset_4;

				SqlCommand TempCommand_5 = null;
				TempCommand_5 = conn.CreateCommand();
				TempCommand_5.CommandText = "delete from ICS_Item_Category";
				TempCommand_5.ExecuteNonQuery();
				mExportedRecord = 0;
				ExportProgress.Value = 0;
				foreach (DataRow iteration_row_2 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("insert into ICS_Item_Category (Cat_Cd, M_Cat_Cd, Cat_No, L_Cat_Name, A_Cat_Name, Cat_Level, Show,");
					mysql.Append(" Protected, Comments, User_Cd, User_Date_Time, row_id)");
					mysql.Append(" values ( " + Convert.ToString(iteration_row_2["Cat_Cd"]) + "," + Convert.ToString(iteration_row_2["M_Cat_Cd"]) + "," + Convert.ToString(iteration_row_2["Cat_No"]) + ",");
					mysql.Append(" '" + Convert.ToString(iteration_row_2["L_Cat_Name"]) + "', '" + Convert.ToString(iteration_row_2["A_Cat_Name"]) + "',");
					mysql.Append(" " + Convert.ToString(iteration_row_2["Cat_Level"]) + "," + Convert.ToString(iteration_row_2["Show"]) + ", ");
					mysql.Append(" " + Convert.ToString(iteration_row_2["Protected"]) + ", '" + Convert.ToString(iteration_row_2["Comments"]) + "', ");
					mysql.Append(" " + Convert.ToString(iteration_row_2["User_Cd"]) + ", '" + Convert.ToString(iteration_row_2["User_Date_Time"]) + "', '" + Convert.ToString(iteration_row_2["row_id"]) + "')");

					SqlCommand TempCommand_6 = null;
					TempCommand_6 = conn.CreateCommand();
					TempCommand_6.CommandText = mysql.ToString();
					TempCommand_6.ExecuteNonQuery();
					ExportProgress.Value = Convert.ToInt32(((mExportedRecord + 1) / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);
				}
				recTempRecord = null;
				//-----------------------------------End Export Item Category-------------------------------------------------

				//--------------------------------------Export Item-------------------------------------------------
				lblExportStatus.Caption = "Exporting Item Master";
				Application.DoEvents();

				mysql = new StringBuilder("select * from ICS_Item where prod_cd in");
				mysql.Append(" (select prod_cd from ICS_Transaction_Details dt inner join ICS_Transaction mt");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportFromDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportToDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + "))");

				SqlCommand TempCommand_7 = null;
				TempCommand_7 = SystemVariables.gConn.CreateCommand();
				TempCommand_7.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_7 = null;
				TempAdapter_7 = new SqlDataAdapter();
				TempAdapter_7.SelectCommand = TempCommand_7;
				DataSet TempDataset_7 = null;
				TempDataset_7 = new DataSet();
				TempAdapter_7.Fill(TempDataset_7);
				recTempRecord = TempDataset_7;

				SqlCommand TempCommand_8 = null;
				TempCommand_8 = conn.CreateCommand();
				TempCommand_8.CommandText = "delete from ICS_Item";
				TempCommand_8.ExecuteNonQuery();
				mExportedRecord = 0;
				ExportProgress.Value = 0;
				foreach (DataRow iteration_row_3 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("insert into ICS_Item (Prod_Cd, Group_Cd, Cat_Cd, Base_Unit_Cd, Item_Type_Cd, Part_No, L_Prod_Name, A_Prod_Name, Prod_Desc,");
					mysql.Append(" Sales_Rate, Comments,Protected, User_Cd, User_Date_Time, row_id, Report_Unit_Cd)");

					mysql.Append(" values ( " + Convert.ToString(iteration_row_3["Prod_Cd"]) + "," + Convert.ToString(iteration_row_3["Group_Cd"]) + "," + Convert.ToString(iteration_row_3["Cat_Cd"]) + "," + Convert.ToString(iteration_row_3["Base_Unit_Cd"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_3["Item_Type_Cd"]) + ",'" + Convert.ToString(iteration_row_3["Part_No"]) + "', '" + Convert.ToString(iteration_row_3["L_Prod_Name"]) + "',");
					mysql.Append(" '" + Convert.ToString(iteration_row_3["A_Prod_Name"]) + "', '" + Convert.ToString(iteration_row_3["Prod_Desc"]) + "',");
					mysql.Append(" " + ((recTempRecord.Tables[0].Rows[0].IsNull("Sales_Rate")) ? "Null" : Convert.ToString(iteration_row_3["Sales_Rate"])) + ", '" + Convert.ToString(iteration_row_3["Comments"]) + "', " + Convert.ToString(iteration_row_3["Protected"]) + ",");
					mysql.Append(" " + Convert.ToString(iteration_row_3["User_Cd"]) + ", '" + Convert.ToString(iteration_row_3["User_Date_Time"]) + "', '" + Convert.ToString(iteration_row_3["row_id"]) + "', ");
					mysql.Append(" " + Convert.ToString(iteration_row_3["Report_Unit_Cd"]) + ") ");

					SqlCommand TempCommand_9 = null;
					TempCommand_9 = conn.CreateCommand();
					TempCommand_9.CommandText = mysql.ToString();
					TempCommand_9.ExecuteNonQuery();
					ExportProgress.Value = Convert.ToInt32((mExportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);
				}
				recTempRecord = null;
				//-----------------------------------End Export Item Master-------------------------------------------------


				//--------------------------------------Export Item Unit-------------------------------------------------
				lblExportStatus.Caption = "Exporting Item Unit Details";
				Application.DoEvents();

				mysql = new StringBuilder("select * from ICS_Item_Unit_Details where prod_cd in");
				mysql.Append(" (select prod_cd from ICS_Transaction_Details dt inner join ICS_Transaction mt");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportFromDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportToDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + "))");

				SqlCommand TempCommand_10 = null;
				TempCommand_10 = SystemVariables.gConn.CreateCommand();
				TempCommand_10.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_10 = null;
				TempAdapter_10 = new SqlDataAdapter();
				TempAdapter_10.SelectCommand = TempCommand_10;
				DataSet TempDataset_10 = null;
				TempDataset_10 = new DataSet();
				TempAdapter_10.Fill(TempDataset_10);
				recTempRecord = TempDataset_10;

				SqlCommand TempCommand_11 = null;
				TempCommand_11 = conn.CreateCommand();
				TempCommand_11.CommandText = "delete from ICS_Item_Unit_Details";
				TempCommand_11.ExecuteNonQuery();
				mExportedRecord = 0;
				ExportProgress.Value = 0;
				foreach (DataRow iteration_row_4 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("insert into ICS_Item_Unit_Details (Unit_Entry_Id, Prod_Cd, Alt_Unit_Cd, Base_Unit_Cd, Base_Qty,");
					mysql.Append(" Alt_Qty, Line_No,Protected, User_Cd, User_Date_Time, row_id, Sales_Rate)");

					mysql.Append(" values ( " + Convert.ToString(iteration_row_4["Unit_Entry_Id"]) + "," + Convert.ToString(iteration_row_4["Prod_Cd"]) + "," + Convert.ToString(iteration_row_4["Alt_Unit_Cd"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_4["Base_Unit_Cd"]) + "," + Convert.ToString(iteration_row_4["Base_Qty"]) + ", " + Convert.ToString(iteration_row_4["Alt_Qty"]) + ",");
					mysql.Append(" " + Convert.ToString(iteration_row_4["Line_No"]) + ", " + Convert.ToString(iteration_row_4["Protected"]) + ",");
					mysql.Append(" " + Convert.ToString(iteration_row_4["User_Cd"]) + ", '" + Convert.ToString(iteration_row_4["User_Date_Time"]) + "', '" + Convert.ToString(iteration_row_4["row_id"]) + "', ");
					mysql.Append(" " + Convert.ToString(iteration_row_4["Sales_Rate"]) + ") ");

					SqlCommand TempCommand_12 = null;
					TempCommand_12 = conn.CreateCommand();
					TempCommand_12.CommandText = mysql.ToString();
					TempCommand_12.ExecuteNonQuery();
					ExportProgress.Value = Convert.ToInt32((mExportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);
				}
				recTempRecord = null;
				//-----------------------------------End Export Item Unit-------------------------------------------------

				//--------------------------------------Export Item Barcode-------------------------------------------------
				lblExportStatus.Caption = "Exporting Item Barcode Details";
				Application.DoEvents();

				mysql = new StringBuilder("select * from ICS_Item_Barcode_Details where prod_cd in");
				mysql.Append(" (select prod_cd from ICS_Transaction_Details dt inner join ICS_Transaction mt");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportFromDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportToDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + "))");

				SqlCommand TempCommand_13 = null;
				TempCommand_13 = SystemVariables.gConn.CreateCommand();
				TempCommand_13.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_13 = null;
				TempAdapter_13 = new SqlDataAdapter();
				TempAdapter_13.SelectCommand = TempCommand_13;
				DataSet TempDataset_13 = null;
				TempDataset_13 = new DataSet();
				TempAdapter_13.Fill(TempDataset_13);
				recTempRecord = TempDataset_13;

				SqlCommand TempCommand_14 = null;
				TempCommand_14 = conn.CreateCommand();
				TempCommand_14.CommandText = "delete from ICS_Item_Barcode_Details";
				TempCommand_14.ExecuteNonQuery();
				mExportedRecord = 0;
				ExportProgress.Value = 0;
				foreach (DataRow iteration_row_5 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("insert into ICS_Item_Barcode_Details (Entry_Id, Prod_Cd, Barcode, Unit_Entry_Id, row_id, Protected)");

					mysql.Append(" values ( " + Convert.ToString(iteration_row_5["Entry_Id"]) + "," + Convert.ToString(iteration_row_5["Prod_Cd"]) + ",'" + Convert.ToString(iteration_row_5["Barcode"]) + "',");
					mysql.Append(Convert.ToString(iteration_row_5["Unit_Entry_Id"]) + ",'" + Convert.ToString(iteration_row_5["row_id"]) + "', " + Convert.ToString(iteration_row_5["Protected"]) + ") ");

					SqlCommand TempCommand_15 = null;
					TempCommand_15 = conn.CreateCommand();
					TempCommand_15.CommandText = mysql.ToString();
					TempCommand_15.ExecuteNonQuery();
					ExportProgress.Value = Convert.ToInt32((mExportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);
				}
				recTempRecord = null;
				//-----------------------------------End Export Item Barcode-------------------------------------------------

				//--------------------------------------Export Transaction Masters-------------------------------------------------
				lblExportStatus.Caption = "Exporting Transaction Master";
				Application.DoEvents();

				mysql = new StringBuilder("select mt.* from ICS_Transaction mt ");

				mysql.Append(" where mt.entry_id in (select entry_id from ICS_Transaction_Details dt where ");
				mysql.Append(" (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + "))");
				mysql.Append(" and mt.Voucher_Date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportFromDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportToDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");

				SqlCommand TempCommand_16 = null;
				TempCommand_16 = SystemVariables.gConn.CreateCommand();
				TempCommand_16.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_16 = null;
				TempAdapter_16 = new SqlDataAdapter();
				TempAdapter_16.SelectCommand = TempCommand_16;
				DataSet TempDataset_16 = null;
				TempDataset_16 = new DataSet();
				TempAdapter_16.Fill(TempDataset_16);
				recTempRecord = TempDataset_16;

				SqlCommand TempCommand_17 = null;
				TempCommand_17 = conn.CreateCommand();
				TempCommand_17.CommandText = "delete from ICS_Transaction";
				TempCommand_17.ExecuteNonQuery();
				mExportedRecord = 0;
				ExportProgress.Value = 0;
				foreach (DataRow iteration_row_6 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("insert into ICS_Transaction (Entry_Id, Voucher_Type, Locat_Cd, Ldgr_Cd, Sman_Cd, Cash_Cd, Exchange_Rate, Voucher_Date, Voucher_No,");
					mysql.Append(" Reference_No, Is_Cash, Voucher_Amt_FC, Voucher_Amt_LC, Discount_Amt_FC, Discount_Amt_LC, Net_Amt_FC, Net_Amt_LC,");
					mysql.Append(" Expenses_Amt, Paid_Amt, Due_Amt, Due_Date, On_Hand_Stock_Affected, Close_Transaction, Comments, User_Cd, User_Date_Time,");
					mysql.Append(" row_id, Curr_Cd, Discount_Percent, Ldgr_Name, Posted_Invnt, Status, Posted_GL_Party, Posted_GL_Expense, Posted_GL_Inventory, Posted_GL)");

					mysql.Append(" values ( " + Convert.ToString(iteration_row_6["Entry_Id"]) + "," + Convert.ToString(iteration_row_6["Voucher_Type"]) + "," + Convert.ToString(iteration_row_6["Locat_Cd"]) + ",");
					mysql.Append(((recTempRecord.Tables[0].Rows[0].IsNull("Ldgr_Cd")) ? "Null" : Convert.ToString(iteration_row_6["Ldgr_Cd"])) + ",");
					mysql.Append(((recTempRecord.Tables[0].Rows[0].IsNull("Sman_Cd")) ? "Null" : Convert.ToString(iteration_row_6["Sman_Cd"])) + "," + ((recTempRecord.Tables[0].Rows[0].IsNull("Cash_Cd")) ? "Null" : Convert.ToString(iteration_row_6["Cash_Cd"])) + ", ");
					mysql.Append(Convert.ToString(iteration_row_6["Exchange_Rate"]) + ",");
					mysql.Append("'" + Convert.ToString(iteration_row_6["Voucher_Date"]) + "'," + Convert.ToString(iteration_row_6["Voucher_No"]) + ", '" + Convert.ToString(iteration_row_6["Reference_No"]) + "',");
					mysql.Append(Convert.ToString(iteration_row_6["Is_Cash"]) + "," + Convert.ToString(iteration_row_6["Voucher_Amt_FC"]) + ", " + Convert.ToString(iteration_row_6["Voucher_Amt_LC"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_6["Discount_Amt_FC"]) + "," + Convert.ToString(iteration_row_6["Discount_Amt_LC"]) + ", " + Convert.ToString(iteration_row_6["Net_Amt_FC"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_6["Net_Amt_LC"]) + "," + Convert.ToString(iteration_row_6["Expenses_Amt"]) + ", " + Convert.ToString(iteration_row_6["Paid_Amt"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_6["Due_Amt"]) + ",'" + Convert.ToString(iteration_row_6["Due_Date"]) + "', " + Convert.ToString(iteration_row_6["On_Hand_Stock_Affected"]) + ", " + Convert.ToString(iteration_row_6["Close_Transaction"]) + ",");
					mysql.Append("'" + Convert.ToString(iteration_row_6["Comments"]) + "'," + Convert.ToString(iteration_row_6["User_Cd"]) + ", '" + Convert.ToString(iteration_row_6["User_Date_Time"]) + "',");
					mysql.Append("'" + Convert.ToString(iteration_row_6["row_id"]) + "'," + ((recTempRecord.Tables[0].Rows[0].IsNull("Curr_Cd")) ? "Null" : Convert.ToString(iteration_row_6["Curr_Cd"])) + ", " + Convert.ToString(iteration_row_6["Discount_Percent"]) + ", '" + Convert.ToString(iteration_row_6["Ldgr_Name"]) + "', ");
					mysql.Append(Convert.ToString(iteration_row_6["Posted_Invnt"]) + "," + Convert.ToString(iteration_row_6["Status"]) + ", " + Convert.ToString(iteration_row_6["Posted_GL_Party"]) + ", ");
					mysql.Append(Convert.ToString(iteration_row_6["Posted_GL_Expense"]) + "," + Convert.ToString(iteration_row_6["Posted_GL_Inventory"]) + ", " + Convert.ToString(iteration_row_6["Posted_GL"]) + ")");
					SqlCommand TempCommand_18 = null;
					TempCommand_18 = conn.CreateCommand();
					TempCommand_18.CommandText = mysql.ToString();
					TempCommand_18.ExecuteNonQuery();
					ExportProgress.Value = Convert.ToInt32((mExportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);
				}
				recTempRecord = null;
				//-----------------------------------End Export Transaction Masters-------------------------------------------------


				//--------------------------------------Export Transaction Details-------------------------------------------------
				lblExportStatus.Caption = "Exporting Transaction Details";
				Application.DoEvents();

				mysql = new StringBuilder("select dt.* from ICS_Transaction_Details dt inner join ICS_Transaction mt ");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportFromDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Date <= '" + ReflectionHelper.GetPrimitiveValue<string>(txtExportToDate.Value) + "'");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + ")");

				SqlCommand TempCommand_19 = null;
				TempCommand_19 = SystemVariables.gConn.CreateCommand();
				TempCommand_19.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_19 = null;
				TempAdapter_19 = new SqlDataAdapter();
				TempAdapter_19.SelectCommand = TempCommand_19;
				DataSet TempDataset_19 = null;
				TempDataset_19 = new DataSet();
				TempAdapter_19.Fill(TempDataset_19);
				recTempRecord = TempDataset_19;

				SqlCommand TempCommand_20 = null;
				TempCommand_20 = conn.CreateCommand();
				TempCommand_20.CommandText = "delete from ICS_Transaction_Details";
				TempCommand_20.ExecuteNonQuery();
				mExportedRecord = 0;
				ExportProgress.Value = 0;
				foreach (DataRow iteration_row_7 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("insert into ICS_Transaction_Details (Line_No, Entry_Id, Add_Locat_Cd, Less_Locat_Cd, Prod_Cd, Unit_Entry_ID, Exchange_Rate, Prod_Name,");
					mysql.Append(" Reference_No, Qty, Base_Qty, Processed_Qty, FC_Rate, FC_Prod_Dis, FC_Amount, Prod_Exp_Amt,");
					mysql.Append(" Dis_In_Percent, Promo_Type, Show, Status, User_Date_Time, row_id, Item_Type_Cd, Pre_Text, Post_Text, Barcode)");

					mysql.Append(" values ( " + Convert.ToString(iteration_row_7["Line_No"]) + "," + Convert.ToString(iteration_row_7["Entry_Id"]) + ", " + ((recTempRecord.Tables[0].Rows[0].IsNull("Add_Locat_Cd")) ? "Null" : Convert.ToString(iteration_row_7["Add_Locat_Cd"])) + ",");
					mysql.Append(((recTempRecord.Tables[0].Rows[0].IsNull("Less_Locat_Cd")) ? "Null" : Convert.ToString(iteration_row_7["Less_Locat_Cd"])) + "," + Convert.ToString(iteration_row_7["Prod_Cd"]) + ", " + Convert.ToString(iteration_row_7["Unit_Entry_ID"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_7["Exchange_Rate"]) + ", '" + Convert.ToString(iteration_row_7["Prod_Name"]) + "', '" + Convert.ToString(iteration_row_7["Reference_No"]) + "',");
					mysql.Append(Convert.ToString(iteration_row_7["Qty"]) + "," + Convert.ToString(iteration_row_7["Base_Qty"]) + ", " + Convert.ToString(iteration_row_7["Processed_Qty"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_7["FC_Rate"]) + "," + Convert.ToString(iteration_row_7["FC_Prod_Dis"]) + ", " + Convert.ToString(iteration_row_7["FC_Amount"]) + ", " + Convert.ToString(iteration_row_7["Prod_Exp_Amt"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_7["Dis_In_Percent"]) + ",'" + Convert.ToString(iteration_row_7["Promo_Type"]) + "', " + Convert.ToString(iteration_row_7["Show"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_7["Status"]) + ", '" + Convert.ToString(iteration_row_7["User_Date_Time"]) + "', '" + Convert.ToString(iteration_row_7["row_id"]) + "',");
					mysql.Append(Convert.ToString(iteration_row_7["Item_Type_Cd"]) + ", '" + Convert.ToString(iteration_row_7["Pre_Text"]) + "', '" + Convert.ToString(iteration_row_7["Post_Text"]) + "','" + Convert.ToString(iteration_row_7["Barcode"]) + "' )");

					SqlCommand TempCommand_21 = null;
					TempCommand_21 = conn.CreateCommand();
					TempCommand_21.CommandText = mysql.ToString();
					TempCommand_21.ExecuteNonQuery();
					ExportProgress.Value = Convert.ToInt32((mExportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);
				}
				recTempRecord = null;
				//-----------------------------------End Export Transaction Masters-------------------------------------------------
				MessageBox.Show("Data Exported successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				CloseForm();
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			return null;
		}

		private void cmdImport_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object SourceFile = null;

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(txtImportLocationCode.Text) || txtImportLocationCode.Text == "")
				{
					MessageBox.Show("Please Select Location", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtImportLocationCode.Focus();
					throw new Exception();
				}
				else if ((Convert.IsDBNull(txtImportPath) || txtImportPath.Text == "") && !ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_dropbox_syncronization")))
				{ 
					MessageBox.Show("Please Enter File Path", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtImportPath.Focus();
					throw new Exception();
				}
				else
				{
					if (!txtImportPath.Visible)
					{
						txtImportPath.Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("dropbox_import_path")) + "\\" + txtImportDisplayLocation.Text + "-" + StringsHelper.Replace(StringsHelper.Replace(DateTimeHelper.ToString(DateTime.Today), "\\", "", 1, -1, CompareMethod.Binary), "-", "", 1, -1, CompareMethod.Binary) + ".exp"; // "-" & DateTime.Date & ".exp"
					}
					SourceFile = txtImportPath.Text;
					ImportData(ReflectionHelper.GetPrimitiveValue<string>(SourceFile));
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private object ImportData(string dbPath)
		{
			int mExportedRecord = 0;

			SqlConnection conn = null;

			DataSet recTempRecord = null;

			StringBuilder mysql = new StringBuilder();

			string txnCodes = "";

			string locationCode = "";

			int mImportedRecord = 0;

			try
			{

				conn = new SqlConnection();

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txnCodes = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Sync_Import_Transaction_Types"));

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				locationCode = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetMasterCode("select locat_cd from SM_Location where locat_no = " + txtImportLocationCode.Text));
				//conn.Open ("Provider=Microsoft.Jet.OLEDB 4.0;Data Source=C:\Program Files\Microsoft Office\Office\Samples\Northwind.mdb;Persist Security Info=False")
				conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + ";Persist Security Info=False";
				//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis#7010
				conn.Open();

				//-----------------------------------------Import Item Group-------------------------------------------------

				lblImportStatus.Caption = "Importing Item Group";

				Application.DoEvents();

				mysql = new StringBuilder("select * from ICS_Item_Group where group_cd in");
				mysql.Append("(select group_cd from ICS_Item where prod_cd in");
				mysql.Append(" (select prod_cd from ICS_Transaction_Details dt inner join ICS_Transaction mt");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportFromDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Date <= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportToDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + ")))");

				recTempRecord = new DataSet();
				SqlCommand TempCommand = null;
				TempCommand = conn.CreateCommand();
				TempCommand.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter = null;
				TempAdapter = new SqlDataAdapter();
				TempAdapter.SelectCommand = TempCommand;
				DataSet TempDataset = null;
				TempDataset = new DataSet();
				TempAdapter.Fill(TempDataset);
				recTempRecord = TempDataset;

				mImportedRecord = 0;
				ImportProgress.Value = 0;

				foreach (DataRow iteration_row in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("if not exists (select * from ICS_Item_Group where Group_cd = " + Convert.ToString(iteration_row["Group_cd"]) + ")");
					mysql.Append("Begin SET IDENTITY_INSERT ICS_Item_Group ON");
					mysql.Append(" insert into ICS_Item_Group ( Group_cd, M_Group_Cd, Group_No, L_Group_Name, A_Group_Name, Group_Level, Show,");
					mysql.Append(" Protected, Comments, User_Cd, User_Date_Time, row_id)");
					mysql.Append(" values (" + Convert.ToString(iteration_row["Group_cd"]) + "," + Convert.ToString(iteration_row["M_Group_Cd"]) + "," + Convert.ToString(iteration_row["Group_No"]) + ",");
					mysql.Append(" '" + Convert.ToString(iteration_row["L_Group_Name"]) + "', '" + Convert.ToString(iteration_row["A_Group_Name"]) + "',");
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql.Append(" " + Convert.ToString(iteration_row["Group_Level"]) + "," + ((((TriState) Convert.ToInt32(iteration_row["Show"])) == TriState.True) ? 1 : 0).ToString() + ", ");
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql.Append(" " + ((((TriState) Convert.ToInt32(iteration_row["Protected"])) == TriState.True) ? 1 : 0).ToString() + ", '" + Convert.ToString(iteration_row["Comments"]) + "', ");
					mysql.Append(" " + Convert.ToString(iteration_row["User_Cd"]) + ", '" + Convert.ToString(iteration_row["User_Date_Time"]) + "', '" + Convert.ToString(iteration_row["row_id"]) + "')");
					mysql.Append(" SET IDENTITY_INSERT ICS_Item_Group off End");

					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql.ToString();
					TempCommand_2.ExecuteNonQuery();
					mImportedRecord++;
					ImportProgress.Value = Convert.ToInt32((mImportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);

				}


				recTempRecord = null;
				//-------------------------------------End Import Item Group-------------------------------------------------

				//-----------------------------------------Import Item Category-------------------------------------------------

				lblImportStatus.Caption = "Importing Item Category";

				Application.DoEvents();

				mysql = new StringBuilder("select * from ICS_Item_Category where Cat_Cd in");
				mysql.Append("(select Cat_Cd from ICS_Item where prod_cd in");
				mysql.Append(" (select prod_cd from ICS_Transaction_Details dt inner join ICS_Transaction mt");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportFromDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Date <= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportToDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + ")))");

				recTempRecord = new DataSet();
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = conn.CreateCommand();
				TempCommand_3.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_3 = null;
				TempAdapter_3 = new SqlDataAdapter();
				TempAdapter_3.SelectCommand = TempCommand_3;
				DataSet TempDataset_3 = null;
				TempDataset_3 = new DataSet();
				TempAdapter_3.Fill(TempDataset_3);
				recTempRecord = TempDataset_3;

				mImportedRecord = 0;
				ImportProgress.Value = 0;

				foreach (DataRow iteration_row_2 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("if not exists (select * from ICS_Item_Category where Cat_Cd = " + Convert.ToString(iteration_row_2["Cat_Cd"]) + ")");
					mysql.Append("Begin SET IDENTITY_INSERT ICS_Item_Category ON");
					mysql.Append(" insert into ICS_Item_Category ( Cat_Cd, M_Cat_Cd, Cat_No, L_Cat_Name, A_Cat_Name, Cat_Level, Show,");
					mysql.Append(" Protected, Comments, User_Cd, User_Date_Time, row_id)");
					mysql.Append(" values (" + Convert.ToString(iteration_row_2["Cat_Cd"]) + "," + Convert.ToString(iteration_row_2["M_Cat_Cd"]) + "," + Convert.ToString(iteration_row_2["Cat_No"]) + ",");
					mysql.Append(" '" + Convert.ToString(iteration_row_2["L_Cat_Name"]) + "', '" + Convert.ToString(iteration_row_2["A_Cat_Name"]) + "',");
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql.Append(" " + Convert.ToString(iteration_row_2["Cat_Level"]) + "," + ((((TriState) Convert.ToInt32(iteration_row_2["Show"])) == TriState.True) ? 1 : 0).ToString() + ", ");
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql.Append(" " + ((((TriState) Convert.ToInt32(iteration_row_2["Protected"])) == TriState.True) ? 1 : 0).ToString() + ", '" + Convert.ToString(iteration_row_2["Comments"]) + "', ");
					mysql.Append(" " + Convert.ToString(iteration_row_2["User_Cd"]) + ", '" + Convert.ToString(iteration_row_2["User_Date_Time"]) + "', '" + Convert.ToString(iteration_row_2["row_id"]) + "')");
					mysql.Append(" SET IDENTITY_INSERT ICS_Item_Category off End");

					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql.ToString();
					TempCommand_4.ExecuteNonQuery();
					mImportedRecord++;
					ImportProgress.Value = Convert.ToInt32((mImportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);

				}


				recTempRecord = null;
				//-------------------------------------End Import Item Category-------------------------------------------------

				//--------------------------------------Import Item-------------------------------------------------
				lblExportStatus.Caption = "Importing Item Master";

				Application.DoEvents();

				mysql = new StringBuilder("select * from ICS_Item");
				mysql.Append(" where prod_cd in (select prod_cd from ICS_Transaction_Details dt inner join ICS_Transaction mt");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportFromDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Date <= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportToDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + "))");

				SqlCommand TempCommand_5 = null;
				TempCommand_5 = conn.CreateCommand();
				TempCommand_5.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_5 = null;
				TempAdapter_5 = new SqlDataAdapter();
				TempAdapter_5.SelectCommand = TempCommand_5;
				DataSet TempDataset_5 = null;
				TempDataset_5 = new DataSet();
				TempAdapter_5.Fill(TempDataset_5);
				recTempRecord = TempDataset_5;

				mImportedRecord = 0;
				ImportProgress.Value = 0;

				foreach (DataRow iteration_row_3 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("declare @pNo nvarchar(50) ");
					mysql.Append(" declare @pNoCount int ");
					mysql.Append(" select @pNoCount = count(Part_No) from ICS_Item where Part_No like '" + Convert.ToString(iteration_row_3["Part_No"]) + "%' ");
					mysql.Append(" if @pNoCount > 0 ");
					mysql.Append(" Begin ");
					mysql.Append(" set @pNo = '" + Convert.ToString(iteration_row_3["Part_No"]) + "-' +  cast(@pNoCount as varchar(5)) ");
					mysql.Append(" End ");
					mysql.Append(" else ");
					mysql.Append(" Begin ");
					mysql.Append(" set @pNo = '" + Convert.ToString(iteration_row_3["Part_No"]) + "'");
					mysql.Append(" End ");
					mysql.Append(" if not exists (select * from ICS_Item where Prod_Cd = " + Convert.ToString(iteration_row_3["Prod_Cd"]) + ")");
					mysql.Append(" Begin ");
					mysql.Append(" alter table ICS_Item");
					mysql.Append(" disable trigger trg_insert_Item ");
					mysql.Append(" SET IDENTITY_INSERT ICS_Item ON");
					mysql.Append(" insert into ICS_Item (Prod_Cd, Group_Cd, Cat_Cd, Base_Unit_Cd, Item_Type_Cd, Part_No, L_Prod_Name, A_Prod_Name, Prod_Desc,");
					mysql.Append(" Sales_Rate, Comments,Protected, User_Cd, User_Date_Time, row_id, Report_Unit_Cd)");
					mysql.Append(" values ( " + Convert.ToString(iteration_row_3["Prod_Cd"]) + "," + Convert.ToString(iteration_row_3["Group_Cd"]) + "," + Convert.ToString(iteration_row_3["Cat_Cd"]) + "," + Convert.ToString(iteration_row_3["Base_Unit_Cd"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_3["Item_Type_Cd"]) + ",");
					mysql.Append(" @pNo, ");
					mysql.Append(" '" + Convert.ToString(iteration_row_3["L_Prod_Name"]) + "',");
					mysql.Append(" '" + Convert.ToString(iteration_row_3["A_Prod_Name"]) + "', '" + Convert.ToString(iteration_row_3["Prod_Desc"]) + "',");
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql.Append(" " + Convert.ToString(iteration_row_3["Sales_Rate"]) + ", '" + Convert.ToString(iteration_row_3["Comments"]) + "', " + ((((TriState) Convert.ToInt32(iteration_row_3["Protected"])) == TriState.True) ? 1 : 0).ToString() + ",");
					mysql.Append(" " + Convert.ToString(iteration_row_3["User_Cd"]) + ", '" + Convert.ToString(iteration_row_3["User_Date_Time"]) + "', '" + Convert.ToString(iteration_row_3["row_id"]) + "', ");
					mysql.Append(" " + Convert.ToString(iteration_row_3["Report_Unit_Cd"]) + ") ");
					mysql.Append(" alter table ICS_Item");
					mysql.Append(" enable trigger trg_insert_Item ");
					mysql.Append(" SET IDENTITY_INSERT ICS_Item off End");

					SqlCommand TempCommand_6 = null;
					TempCommand_6 = SystemVariables.gConn.CreateCommand();
					TempCommand_6.CommandText = mysql.ToString();
					TempCommand_6.ExecuteNonQuery();
					mImportedRecord++;
					ImportProgress.Value = Convert.ToInt32((mImportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);

				}


				recTempRecord = null;
				//-----------------------------------End Import Item Master-------------------------------------------------

				//--------------------------------------Import Item Unit-------------------------------------------------
				lblExportStatus.Caption = "Importing Item Unit Details";

				Application.DoEvents();

				mysql = new StringBuilder("select * from ICS_Item_Unit_Details where prod_cd in");
				mysql.Append(" (select prod_cd from ICS_Transaction_Details dt inner join ICS_Transaction mt");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportFromDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Date <= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportToDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + "))");

				SqlCommand TempCommand_7 = null;
				TempCommand_7 = conn.CreateCommand();
				TempCommand_7.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_7 = null;
				TempAdapter_7 = new SqlDataAdapter();
				TempAdapter_7.SelectCommand = TempCommand_7;
				DataSet TempDataset_7 = null;
				TempDataset_7 = new DataSet();
				TempAdapter_7.Fill(TempDataset_7);
				recTempRecord = TempDataset_7;

				mImportedRecord = 0;
				ImportProgress.Value = 0;

				foreach (DataRow iteration_row_4 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("if not exists (select * from ICS_Item_Unit_Details where Unit_Entry_Id = " + Convert.ToString(iteration_row_4["Unit_Entry_Id"]) + ")");
					mysql.Append("Begin SET IDENTITY_INSERT ICS_Item_Unit_Details ON");
					mysql.Append(" insert into ICS_Item_Unit_Details (Unit_Entry_Id, Prod_Cd, Alt_Unit_Cd, Base_Unit_Cd, Base_Qty,");
					mysql.Append(" Alt_Qty, Line_No,Protected, User_Cd, User_Date_Time, row_id, Sales_Rate)");
					mysql.Append(" values ( " + Convert.ToString(iteration_row_4["Unit_Entry_Id"]) + "," + Convert.ToString(iteration_row_4["Prod_Cd"]) + "," + Convert.ToString(iteration_row_4["Alt_Unit_Cd"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_4["Base_Unit_Cd"]) + "," + Convert.ToString(iteration_row_4["Base_Qty"]) + ", " + Convert.ToString(iteration_row_4["Alt_Qty"]) + ",");
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql.Append(" " + Convert.ToString(iteration_row_4["Line_No"]) + ", " + ((((TriState) Convert.ToInt32(iteration_row_4["Protected"])) == TriState.True) ? 1 : 0).ToString() + ",");
					mysql.Append(" " + Convert.ToString(iteration_row_4["User_Cd"]) + ", '" + Convert.ToString(iteration_row_4["User_Date_Time"]) + "', '" + Convert.ToString(iteration_row_4["row_id"]) + "', ");
					mysql.Append(" " + Convert.ToString(iteration_row_4["Sales_Rate"]) + ") ");
					mysql.Append(" SET IDENTITY_INSERT ICS_Item_Unit_Details off End");

					SqlCommand TempCommand_8 = null;
					TempCommand_8 = SystemVariables.gConn.CreateCommand();
					TempCommand_8.CommandText = mysql.ToString();
					TempCommand_8.ExecuteNonQuery();
					mImportedRecord++;
					ImportProgress.Value = Convert.ToInt32((mImportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);

				}


				recTempRecord = null;
				//-----------------------------------End Import Item Unit-------------------------------------------------

				//--------------------------------------Import Item Barcode-------------------------------------------------
				lblExportStatus.Caption = "Importing Item Barcode Details";

				Application.DoEvents();

				mysql = new StringBuilder("select * from ICS_Item_Barcode_Details where prod_cd in");
				mysql.Append(" (select prod_cd from ICS_Transaction_Details dt inner join ICS_Transaction mt");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportFromDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Date <= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportToDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + "))");

				SqlCommand TempCommand_9 = null;
				TempCommand_9 = conn.CreateCommand();
				TempCommand_9.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_9 = null;
				TempAdapter_9 = new SqlDataAdapter();
				TempAdapter_9.SelectCommand = TempCommand_9;
				DataSet TempDataset_9 = null;
				TempDataset_9 = new DataSet();
				TempAdapter_9.Fill(TempDataset_9);
				recTempRecord = TempDataset_9;

				mImportedRecord = 0;
				ImportProgress.Value = 0;

				foreach (DataRow iteration_row_5 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("if not exists (select * from ICS_Item_Barcode_Details where Entry_Id = " + Convert.ToString(iteration_row_5["Entry_Id"]) + ")");
					mysql.Append("Begin SET IDENTITY_INSERT ICS_Item_Barcode_Details ON");
					mysql.Append(" insert into ICS_Item_Barcode_Details (Entry_Id, Prod_Cd, Barcode, Unit_Entry_Id, row_id, Protected)");

					mysql.Append(" values ( " + Convert.ToString(iteration_row_5["Entry_Id"]) + "," + Convert.ToString(iteration_row_5["Prod_Cd"]) + ",'" + Convert.ToString(iteration_row_5["Barcode"]) + "',");
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql.Append(Convert.ToString(iteration_row_5["Unit_Entry_Id"]) + ",'" + Convert.ToString(iteration_row_5["row_id"]) + "', " + ((((TriState) Convert.ToInt32(iteration_row_5["Protected"])) == TriState.True) ? 1 : 0).ToString() + ") ");
					mysql.Append(" SET IDENTITY_INSERT ICS_Item_Barcode_Details off End");

					SqlCommand TempCommand_10 = null;
					TempCommand_10 = SystemVariables.gConn.CreateCommand();
					TempCommand_10.CommandText = mysql.ToString();
					TempCommand_10.ExecuteNonQuery();
					mImportedRecord++;
					ImportProgress.Value = Convert.ToInt32((mImportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);

				}


				recTempRecord = null;
				//-----------------------------------End Import Item Barcode-------------------------------------------------

				//--------------------------------------Import Transaction Masters-------------------------------------------------
				lblExportStatus.Caption = "Importing Transaction Master";

				Application.DoEvents();

				mysql = new StringBuilder("select mt.* from ICS_Transaction mt");
				mysql.Append(" where mt.entry_id in (select entry_id from ICS_Transaction_Details dt where ");
				mysql.Append(" (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + "))");
				mysql.Append(" and mt.Voucher_Date >= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportFromDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Date <= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportToDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");

				SqlCommand TempCommand_11 = null;
				TempCommand_11 = conn.CreateCommand();
				TempCommand_11.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_11 = null;
				TempAdapter_11 = new SqlDataAdapter();
				TempAdapter_11.SelectCommand = TempCommand_11;
				DataSet TempDataset_11 = null;
				TempDataset_11 = new DataSet();
				TempAdapter_11.Fill(TempDataset_11);
				recTempRecord = TempDataset_11;

				mImportedRecord = 0;
				ImportProgress.Value = 0;

				foreach (DataRow iteration_row_6 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("if not exists (select * from ICS_Transaction where row_id = '" + Convert.ToString(iteration_row_6["row_id"]) + "')");
					mysql.Append(" Begin");
					mysql.Append(" insert into ICS_Transaction (Voucher_Type, Locat_Cd, Ldgr_Cd, Sman_Cd, Cash_Cd, Exchange_Rate, Voucher_Date, Voucher_No,");
					mysql.Append(" Reference_No, Is_Cash, Voucher_Amt_FC, Discount_Amt_FC,");
					mysql.Append(" Expenses_Amt, Paid_Amt, Due_Amt, Due_Date, On_Hand_Stock_Affected, Close_Transaction, Comments, User_Cd, User_Date_Time,");
					mysql.Append(" row_id, Curr_Cd, Discount_Percent, Ldgr_Name)");

					mysql.Append(" values ( " + Convert.ToString(iteration_row_6["Voucher_Type"]) + "," + Convert.ToString(iteration_row_6["Locat_Cd"]) + ",");
					mysql.Append(((recTempRecord.Tables[0].Rows[0].IsNull("Ldgr_Cd")) ? "Null" : Convert.ToString(iteration_row_6["Ldgr_Cd"])) + ",");
					mysql.Append(((recTempRecord.Tables[0].Rows[0].IsNull("Sman_Cd")) ? "Null" : Convert.ToString(iteration_row_6["Sman_Cd"])) + "," + ((recTempRecord.Tables[0].Rows[0].IsNull("Cash_Cd")) ? "Null" : Convert.ToString(iteration_row_6["Cash_Cd"])) + ", ");
					mysql.Append(Convert.ToString(iteration_row_6["Exchange_Rate"]) + ",");
					mysql.Append("'" + Convert.ToString(iteration_row_6["Voucher_Date"]) + "'," + Convert.ToString(iteration_row_6["Voucher_No"]) + ", '" + Convert.ToString(iteration_row_6["Reference_No"]) + "',");
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql.Append(((((TriState) Convert.ToInt32(iteration_row_6["Is_Cash"])) == TriState.True) ? 1 : 0).ToString() + "," + Convert.ToString(iteration_row_6["Voucher_Amt_FC"]) + ", ");
					mysql.Append(Convert.ToString(iteration_row_6["Discount_Amt_FC"]) + "," + Convert.ToString(iteration_row_6["Expenses_Amt"]) + ", " + Convert.ToString(iteration_row_6["Paid_Amt"]) + ",");
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql.Append(Convert.ToString(iteration_row_6["Due_Amt"]) + ",'" + Convert.ToString(iteration_row_6["Due_Date"]) + "', " + ((((TriState) Convert.ToInt32(iteration_row_6["On_Hand_Stock_Affected"])) == TriState.True) ? 1 : 0).ToString() + ", " + ((((TriState) Convert.ToInt32(iteration_row_6["Close_Transaction"])) == TriState.True) ? 1 : 0).ToString() + ",");
					mysql.Append("'" + Convert.ToString(iteration_row_6["Comments"]) + "'," + Convert.ToString(iteration_row_6["User_Cd"]) + ", '" + Convert.ToString(iteration_row_6["User_Date_Time"]) + "',");
					mysql.Append("'" + Convert.ToString(iteration_row_6["row_id"]) + "'," + ((recTempRecord.Tables[0].Rows[0].IsNull("Curr_Cd")) ? "Null" : Convert.ToString(iteration_row_6["Curr_Cd"])) + ", ");
					mysql.Append(Convert.ToString(iteration_row_6["Discount_Percent"]) + ", '" + Convert.ToString(iteration_row_6["Ldgr_Name"]) + "')");
					mysql.Append(" End");

					SqlCommand TempCommand_12 = null;
					TempCommand_12 = SystemVariables.gConn.CreateCommand();
					TempCommand_12.CommandText = mysql.ToString();
					TempCommand_12.ExecuteNonQuery();
					mImportedRecord++;
					ImportProgress.Value = Convert.ToInt32((mImportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);
				}


				recTempRecord = null;
				//-----------------------------------End Import Transaction Masters-------------------------------------------------

				//--------------------------------------Import Transaction Details-------------------------------------------------
				lblExportStatus.Caption = "Importing Transaction Details";

				Application.DoEvents();

				mysql = new StringBuilder("select dt.*, mt.row_id as parent_row_id from ICS_Transaction_Details dt inner join ICS_Transaction mt ");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportFromDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Date <= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportToDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + ")");

				SqlCommand TempCommand_13 = null;
				TempCommand_13 = conn.CreateCommand();
				TempCommand_13.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_13 = null;
				TempAdapter_13 = new SqlDataAdapter();
				TempAdapter_13.SelectCommand = TempCommand_13;
				DataSet TempDataset_13 = null;
				TempDataset_13 = new DataSet();
				TempAdapter_13.Fill(TempDataset_13);
				recTempRecord = TempDataset_13;

				mExportedRecord = 0;
				ExportProgress.Value = 0;

				foreach (DataRow iteration_row_7 in recTempRecord.Tables[0].Rows)
				{
					mysql = new StringBuilder("if not exists (select * from ICS_Transaction_Details where row_id = '" + Convert.ToString(iteration_row_7["row_id"]) + "')");
					mysql.Append(" Begin");
					mysql.Append(" insert into ICS_Transaction_Details (Entry_Id, Add_Locat_Cd, Less_Locat_Cd, Prod_Cd, Unit_Entry_ID, Exchange_Rate, Prod_Name,");
					mysql.Append(" Reference_No, Qty, Base_Qty, Processed_Qty, FC_Rate, FC_Prod_Dis, FC_Amount, Prod_Exp_Amt,");
					mysql.Append(" Dis_In_Percent, Promo_Type, Show, Status, User_Date_Time, row_id, Item_Type_Cd, Pre_Text, Post_Text, Barcode)");

					mysql.Append(" select entry_id, " + ((recTempRecord.Tables[0].Rows[0].IsNull("Add_Locat_Cd")) ? "Null" : Convert.ToString(iteration_row_7["Add_Locat_Cd"])) + ",");
					mysql.Append(((recTempRecord.Tables[0].Rows[0].IsNull("Less_Locat_Cd")) ? "Null" : Convert.ToString(iteration_row_7["Less_Locat_Cd"])) + "," + Convert.ToString(iteration_row_7["Prod_Cd"]) + ", " + Convert.ToString(iteration_row_7["Unit_Entry_ID"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_7["Exchange_Rate"]) + ", '" + Convert.ToString(iteration_row_7["Prod_Name"]) + "', '" + Convert.ToString(iteration_row_7["Reference_No"]) + "',");
					mysql.Append(Convert.ToString(iteration_row_7["Qty"]) + "," + Convert.ToString(iteration_row_7["Base_Qty"]) + ", " + Convert.ToString(iteration_row_7["Processed_Qty"]) + ",");
					mysql.Append(Convert.ToString(iteration_row_7["FC_Rate"]) + "," + Convert.ToString(iteration_row_7["FC_Prod_Dis"]) + ", " + Convert.ToString(iteration_row_7["FC_Amount"]) + ", " + Convert.ToString(iteration_row_7["Prod_Exp_Amt"]) + ",");
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql.Append(((((TriState) Convert.ToInt32(iteration_row_7["Dis_In_Percent"])) == TriState.True) ? 1 : 0).ToString() + ",'" + Convert.ToString(iteration_row_7["Promo_Type"]) + "', " + ((((TriState) Convert.ToInt32(iteration_row_7["Show"])) == TriState.True) ? 1 : 0).ToString() + ",");
					mysql.Append(Convert.ToString(iteration_row_7["Status"]) + ", '" + Convert.ToString(iteration_row_7["User_Date_Time"]) + "', '" + Convert.ToString(iteration_row_7["row_id"]) + "',");
					mysql.Append(Convert.ToString(iteration_row_7["Item_Type_Cd"]) + ", '" + Convert.ToString(iteration_row_7["Pre_Text"]) + "', '" + Convert.ToString(iteration_row_7["Post_Text"]) + "','" + Convert.ToString(iteration_row_7["Barcode"]) + "'");
					mysql.Append(" from ICS_Transaction where row_id = '" + Convert.ToString(iteration_row_7["parent_row_id"]) + "' End");

					SqlCommand TempCommand_14 = null;
					TempCommand_14 = SystemVariables.gConn.CreateCommand();
					TempCommand_14.CommandText = mysql.ToString();
					TempCommand_14.ExecuteNonQuery();
					mImportedRecord++;
					ImportProgress.Value = Convert.ToInt32((mImportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);

				}


				recTempRecord = null;
				//-----------------------------------End Import Transaction Masters-------------------------------------------------

				//--------------------------------------Post Transactions-------------------------------------------------
				lblExportStatus.Caption = "Posting Transactions";

				Application.DoEvents();

				int mEntryId = 0;

				string masterTableName = "";

				masterTableName = "ICS_Transaction";

				mysql = new StringBuilder("select mt.* from ICS_Transaction mt inner join ICS_Transaction_Details dt ");
				mysql.Append(" on dt.entry_id = mt.entry_id where mt.Voucher_Date >= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportFromDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Date <= #" + ReflectionHelper.GetPrimitiveValue<string>(txtImportToDate.Value) + "#");
				mysql.Append(" and mt.Voucher_Type in (" + txnCodes + ")");
				mysql.Append(" and (dt.Add_Locat_Cd = " + locationCode + " or dt.Less_Locat_Cd = " + locationCode + ")");

				SqlCommand TempCommand_15 = null;
				TempCommand_15 = conn.CreateCommand();
				TempCommand_15.CommandText = mysql.ToString();
				SqlDataAdapter TempAdapter_15 = null;
				TempAdapter_15 = new SqlDataAdapter();
				TempAdapter_15.SelectCommand = TempCommand_15;
				DataSet TempDataset_15 = null;
				TempDataset_15 = new DataSet();
				TempAdapter_15.Fill(TempDataset_15);
				recTempRecord = TempDataset_15;

				mImportedRecord = 0;
				ImportProgress.Value = 0;

				foreach (DataRow iteration_row_8 in recTempRecord.Tables[0].Rows)
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select Entry_id from ICS_Transaction where row_id = '" + Convert.ToString(iteration_row_8["row_id"]) + "'"));

					if (mEntryId != 0)
					{

						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(iteration_row_8["Posted_Invnt"])) == TriState.True)
						{
							SystemICSProcedure.PostTransactionToIcs(masterTableName, mEntryId);
						}

						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) Convert.ToInt32(iteration_row_8["Posted_GL_Party"])) == TriState.True)
						{
							SystemICSProcedure.PostTransactionToGLParty(masterTableName, mEntryId);
						}

						//                If chkPostTransactions.Value = 1 Then
						//                    If .Fields("Status").Value = "2" Then
						//                        Call ApproveTransaction(masterTableName, mEntryID)
						//                    End If
						//
						//                    If .Fields("Posted_GL_Expense").Value = vbTrue Then
						//                        Call PostTransactionToGLExpenses(masterTableName, mEntryID, False)
						//                    End If
						//
						//                    If .Fields("Posted_GL_Inventory").Value = vbTrue Then
						//                        Call PostTransactionToGLInventory(masterTableName, mEntryID, False)
						//                    End If
						//
						//                    If .Fields("Posted_GL").Value = vbTrue Then
						//                        Call PostTransactionToGL(masterTableName, mEntryID, False)
						//                    End If
						//                End If
					}

					mImportedRecord++;
					ImportProgress.Value = Convert.ToInt32((mImportedRecord / ((double) recTempRecord.Tables[0].Rows.Count)) * 100);
				}


				recTempRecord = null;
				//-----------------------------------End Import Transaction Masters-------------------------------------------------

				MessageBox.Show("Data Imported successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				CloseForm();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			return null;
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				clsHourGlass myHourGlass = null;
				try
				{
					myHourGlass = new clsHourGlass();


					return;
				}
				catch (System.Exception excep)
				{
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					MessageBox.Show(Information.Err().Number.ToString() + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

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
			clsHourGlass myHourGlass = null;
			try
			{
				object locatNo = null;
				myHourGlass = new clsHourGlass();

				if (SystemVariables.gIsHeadOffice)
				{
					lblExportLocation.Caption = "To Location";
					lblImportLocation.Caption = "From Location";
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					locatNo = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select locat_no from SM_Location where locat_cd = " + SystemVariables.gLoggedInUserLocationCode.ToString()));
					lblExportLocation.Caption = "Location Code";
					//UPGRADE_WARNING: (1068) locatNo of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtExportLocationCode.Text = ReflectionHelper.GetPrimitiveValue<string>(locatNo);
					txtExportLocationCode_Leave(txtExportLocationCode, new EventArgs());

					txtExportLocationCode.Enabled = false;
					lblImportLocation.Caption = "Location Code";
					//UPGRADE_WARNING: (1068) locatNo of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtImportLocationCode.Text = ReflectionHelper.GetPrimitiveValue<string>(locatNo);
					txtImportLocationCode_Leave(txtImportLocationCode, new EventArgs());
					txtImportLocationCode.Enabled = false;
				}

				txtExportFromDate.Value = DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Today.Month).Trim() + "-" + Conversion.Str(DateTime.Today.Year));
				txtExportToDate.Value = DateTime.Today;
				txtImportFromDate.Value = DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Today.Month).Trim() + "-" + Conversion.Str(DateTime.Today.Year));
				txtImportToDate.Value = DateTime.Today;

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_dropbox_syncronization")))
				{
					txtExportPath.Visible = false;
					txtImportPath.Visible = false;
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			//cntOuterFrame.Width = Me.Width - 100
			//tabMaster.Width = Me.Width - 100
			//
			//cntOuterFrame.Height = Me.Height - 400
			//tabMaster.Height = Me.Height - 600
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmSysMenus.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void txtExportLocationCode_DropButtonClick(Object Sender, EventArgs e)
		{


			txtExportLocationCode.Text = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000, "82"));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtExportLocationCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtExportLocationCode_Leave(txtExportLocationCode, new EventArgs());
			}

		}

		private void txtExportPath_DropButtonClick(Object Sender, EventArgs e)
		{
			txtExportPath.Text = BrowseFolder("Select Path", "C");
		}

		public string BrowseFolder(string Caption = "", string InitialFolder = "")
		{
			string result = "";
			string sBuffer = "";
			InnovaUpdSupport.PInvoke.UnsafeNative.Structures.BrowseInfo tBrowseInfo = new InnovaUpdSupport.PInvoke.UnsafeNative.Structures.BrowseInfo();

			string szTitle = Caption;
			tBrowseInfo.hWndOwner = this.Handle.ToInt32();
			string tempRefParam = "";
			tBrowseInfo.lpszTitle = InnovaUpdSupport.PInvoke.SafeNative.kernel32.lstrcat(ref szTitle, ref tempRefParam);
			tBrowseInfo.ulFlags = BIF_RETURNONLYFSDIRS + BIF_DONTGOBELOWDOMAIN;

			int lpIDList = InnovaUpdSupport.PInvoke.SafeNative.shell32.SHBrowseForFolder(ref tBrowseInfo);

			if (lpIDList != 0)
			{
				sBuffer = new String(' ', MAX_PATH);
				InnovaUpdSupport.PInvoke.SafeNative.shell32.SHGetPathFromIDList(lpIDList, ref sBuffer);
				sBuffer = sBuffer.Substring(0, Math.Min(sBuffer.IndexOf("\0"), sBuffer.Length));
				result = sBuffer;
			}
			return result;
		}

		//Function BrowseFolder(Optional Caption As String, Optional InitialFolder As String) As String
		//'You need to set reference to Microsoft shell controls and automation
		//    Dim SH As shell32.Shell
		//    Dim F As shell32.Folder
		//    Set SH = New shell32.Shell
		//    Set F = SH.BrowseForFolder(0&, Caption, BIF_RETURNONLYFSDIRS, InitialFolder)
		//    If Not F Is Nothing Then
		//        BrowseFolder = F.Items.Item.Path
		//    End If
		//End Function

		private void txtExportLocationCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			object txtLocationName = null;

			object mLocationDetails = null;

			string mysql = "";

			try
			{

				if (!SystemProcedure2.IsItEmpty(txtExportLocationCode.Text, SystemVariables.DataType.StringType))
				{

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLocationDetails = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name") + "  , locat_cd from SM_Location where locat_no ='" + txtExportLocationCode.Text + "'"));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mLocationDetails))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mLocationDetails = DBNull.Value;
						ReflectionHelper.LetMember(txtLocationName, "Text", "");
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mLocationDetails() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtExportDisplayLocation.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(0));

					}

				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mLocationDetails = DBNull.Value;
					txtExportDisplayLocation.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mLocationDetails = DBNull.Value;

				if (mReturnErrorType == 4)
				{
					txtExportLocationCode.Focus();
				}
			}

		}

		private void txtImportLocationCode_DropButtonClick(Object Sender, EventArgs e)
		{
			txtImportLocationCode.Text = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000, "82"));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtImportLocationCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtImportLocationCode_Leave(txtImportLocationCode, new EventArgs());
			}

		}

		private void txtImportPath_DropButtonClick(Object Sender, EventArgs e)
		{
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			CommonDialog1Open.FileName = "";
			//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
			//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
			CommonDialog1Open.ShowReadOnly = false;
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			CommonDialog1Open.Filter = "Innova Export File (*.exp)|*.exp";
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FilterIndex was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			CommonDialog1Open.FilterIndex = 2;
			CommonDialog1Open.ShowDialog();

			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			if (CommonDialog1Open.FileName != "")
			{
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				txtImportPath.Text = CommonDialog1Open.FileName;

			}
		}

		private void txtImportLocationCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			object txtLocationName = null;

			object mLocationDetails = null;

			string mysql = "";

			try
			{

				if (!SystemProcedure2.IsItEmpty(txtImportLocationCode.Text, SystemVariables.DataType.StringType))
				{

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLocationDetails = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name") + "  , locat_cd from SM_Location where locat_no ='" + txtImportLocationCode.Text + "'"));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mLocationDetails))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mLocationDetails = DBNull.Value;
						ReflectionHelper.LetMember(txtLocationName, "Text", "");
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mLocationDetails() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtImportDisplayLocation.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mLocationDetails).GetValue(0));

					}

				}
				else
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mLocationDetails = DBNull.Value;
					txtImportDisplayLocation.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mLocationDetails = DBNull.Value;

				if (mReturnErrorType == 4)
				{
					txtExportLocationCode.Focus();
				}
			}

		}

		public void FindRoutine(string pObjectName)
		{

			string mObjectName = pObjectName;
			//mIndex = CInt(Mid(pObjectName, InStr(1, pObjectName, "#", vbTextCompare) + 1))

		}
	}
}