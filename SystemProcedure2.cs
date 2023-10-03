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
    public class SystemProcedure2
    {
        internal static object GetMasterCode(string pSqlString, bool isSystem = false)
        {
            object result = null;
            DataSet rsTempRec = null;
            //ADODB.Field mField = null;
            int Cnt = 0;
            object[] aFieldValues = null;

            try
            {

                rsTempRec = new DataSet();
                SqlDataAdapter adap = SharpHelper.GetSqlDataAdapter(pSqlString);
                rsTempRec.Tables.Clear();
                adap.Fill(rsTempRec);

                if (rsTempRec.Tables[0].Rows.Count != 0)
                {
                    

                    if (rsTempRec.Tables[0].Rows[0].ItemArray.Length> 1)
                    {
                        //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                        aFieldValues = new object[rsTempRec.Tables[0].Columns.Count];
                        //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                        foreach (var item in rsTempRec.Tables[0].Rows[0].ItemArray)
                        {
                            aFieldValues[Cnt] = item;
                            Cnt++;
                        }

                        result = aFieldValues;
                    }
                    else
                    {
                        //UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
                        result = rsTempRec.Tables[0].Rows[0][0];
                    }
                }
                else
                {
                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
                    result = DBNull.Value;
                }
                rsTempRec = null;
            }
            catch (System.Exception excep)
            {

                frmSysSplash.DefInstance.Close();
                MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

                //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
                result = DBNull.Value;
            }
            return result;
        }


    }
}
