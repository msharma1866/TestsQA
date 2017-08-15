using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsQA
{
    public class ExcelToDataTableHelper
    {
        public DataTable dataTable { get; set; }
        public ExcelToDataTableHelper()
        {

        }

        public DataTable GetDataTableFromExcel()
        {
            string connStr = "";
            string fileExtension = "xlsx";
            string filename = "C:\\BUILD_AUTOMATION\\Task_Data.xlsx";
            if (fileExtension == ".xls" || fileExtension == ".XLS")
            {
                connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";

            }
            else if (fileExtension == ".xlsx" || fileExtension == ".XLSX")
            {
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }

            OleDbConnection conn = new OleDbConnection(connStr);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Open();
            DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetName = dtSheet.Rows[0]["table_name"].ToString();
            cmd.CommandText = "select * from [" + sheetName + "]";
            da.SelectCommand = cmd;
            da.Fill(dt);
            conn.Close();
            dataTable = dt;
            return dt;
        }

        public List<Dictionary<string,object>> GetDataByProperty(string propName)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            var rows = dataTable.Select("Property= '" + propName + "'");
            foreach(DataRow row in rows)
            {
                dictionary.Add(row["value"].ToString(), row["expected_value"]);
                list.Add(dictionary);
            }
            return list;
        }
    
    }
}
