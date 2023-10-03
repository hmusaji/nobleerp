using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xtreme
{
    public class SystemCombo
    {

        public static void FillComboWithItemData(ComboBox pCombo, string pMysql, bool SelectFirstComboItem = false, bool SelectLastComboItem = false)
        {
            DataSet rsComboList = new DataSet();


            SqlDataAdapter adap = SharpHelper.GetSqlDataAdapter(pMysql);
            rsComboList.Tables.Clear();
            adap.Fill(rsComboList);
            pCombo.ValueMember = "id";
            pCombo.DisplayMember = "name";
            pCombo.DataSource = rsComboList?.Tables?[0];
        }

    }
}
