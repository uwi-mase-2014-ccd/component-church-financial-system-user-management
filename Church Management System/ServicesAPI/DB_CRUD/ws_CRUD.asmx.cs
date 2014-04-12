using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using MySql.Data.MySqlClient;
using ServicesAPI.DataManager;
using ServicesAPI.Model;

namespace ServicesAPI.DB_CRUD
{
    /// <summary>
    /// Summary description for ws_CRUD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ws_CRUD : System.Web.Services.WebService
    {


        /// <summary>
        /// get connection string data source 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="databaseType"></param>
        /// <returns></returns>
        [WebMethod]
        public Object GetResultFromSource(String server, String database, String UserId, String Password, String databaseType, String query)
        {
            //ConnectionInfo info;
            String conStringFrame;
            String fullConnectionString;
            JavaScriptSerializer jss;
            int code = 0;
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            String debugData = "";
            String message = "";
            ConnectionStringMgr csmgr = new ConnectionStringMgr();
            //Object connection;
            //SqlConnection connection;
            string queryType = (query.Trim()).Split(' ')[0];
            //path to connection string framework file
            String path = Server.MapPath(@"~\DataManager\ConnectionStringDef.xml");

            String DBtype = databaseType;
            switch (DBtype)
            {
                case "mysql":
                    MySqlConnection mysqlconnection = null;
                    DataTable table1 = null;
                    try
                    {
                        List<String> ls = new List<String>();

                        conStringFrame = csmgr.getConnectionInfo(path, databaseType);
                        fullConnectionString = String.Format(conStringFrame, server, database, UserId, Password);
                        mysqlconnection = new MySqlConnection(fullConnectionString);
                        mysqlconnection.Open();
                        MySqlCommand mysqlcommand = new MySqlCommand(query, mysqlconnection);
                        if (queryType.ToLower() == "select")
                        {
                            table1 = new DataTable();
                            MySqlDataAdapter dadap = new MySqlDataAdapter(mysqlcommand);
                            dadap.Fill(table1);
                            //data.Add(table1);

                            //List<Dictionary<string, object>> rows =  new List<Dictionary<string, object>>();
                            //Dictionary<string, object> row = null;

                            foreach (DataRow dr in table1.Rows)
                            {
                                row = new Dictionary<string, object>();
                                foreach (DataColumn col in table1.Columns)
                                {
                                    row.Add(col.ColumnName.Trim(), dr[col]);
                                }
                                rows.Add(row);
                            }
                        }
                        else if (queryType.ToLower() == "update" || queryType.ToLower() == "delete" || queryType.ToLower() == "insert")
                            if (mysqlcommand.ExecuteNonQuery() == -1)
                            {
                                if (queryType.ToLower() == "delete")
                                {
                                    row.Add("delete", "records were deleted");
                                    rows.Add(row);
                                    code = 223;
                                }
                                if (queryType.ToLower() == "update")
                                {
                                    row.Add("update", "records were updated");
                                    rows.Add(row);
                                    //data.Add("records were updated");
                                    code = 223;
                                }
                                //data.Add("records loaded");
                                if (queryType.ToLower() == "insert")
                                {
                                    row.Add("insert", "records were inserted");
                                    rows.Add(row);
                                    //data.Add("records were updated");
                                    code = 223;
                                }
                            }
                    }



                    catch (SqlException msex)
                    {
                        code = 224;
                        row.Add("sqlException", "no records loaded because an sql exception was thrown");
                        rows.Add(row);
                        message = msex.ToString();
                    }
                    catch (Exception ex)
                    {
                        code = 225;
                        row.Add("Exception", "no records loaded because an sql exception was thrown");
                        rows.Add(row);
                        message = ex.ToString();
                    }
                    finally
                    {
                        mysqlconnection.Close();
                    }
                    break;
                case "mssql":
                    DataTable table = null;
                    SqlConnection sqlconnection = null;
                    try
                    {
                        //query = query.Trim();

                        conStringFrame = csmgr.getConnectionInfo(path, databaseType);
                        fullConnectionString = String.Format(conStringFrame, server, database, UserId, Password);
                        sqlconnection = new SqlConnection(fullConnectionString);
                        sqlconnection.Open();
                        SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);
                        if (queryType.ToLower() == "select")
                        {
                            table = new DataTable();
                            SqlDataAdapter dadap = new SqlDataAdapter(sqlcommand);
                            dadap.Fill(table);
                            foreach (DataRow dr in table.Rows)
                            {
                                row = new Dictionary<string, object>();
                                foreach (DataColumn col in table.Columns)
                                {
                                    row.Add(col.ColumnName.Trim(), dr[col]);
                                }
                                rows.Add(row);
                            }
                            code = 223;
                        }
                        else if (queryType.ToLower() == "update" || queryType.ToLower() == "delete" || queryType.ToLower() == "insert")
                            if (sqlcommand.ExecuteNonQuery() == -1)
                            {
                                if (queryType.ToLower() == "delete")
                                {
                                    row.Add("delete", "records were deleted");
                                    rows.Add(row);
                                    code = 223;
                                }
                                if (queryType.ToLower() == "update")
                                {
                                    row.Add("update", "records were updated");
                                    rows.Add(row);
                                    //data.Add("records were updated");
                                    code = 223;
                                }

                                if (queryType.ToLower() == "insert")
                                {
                                    row.Add("insert", "records were inserted");
                                    rows.Add(row);
                                    //data.Add("records were updated");
                                    code = 223;
                                }
                                //data.Add("records loaded");
                            }


                    }
                    catch (SqlException msex)
                    {
                        code = 224;
                        row.Add("sqlException", "no records loaded because an sql exception was thrown");
                        rows.Add(row);
                        message = msex.ToString();
                    }
                    catch (Exception ex)
                    {
                        code = 225;
                        row.Add("Exception", "no records loaded because an sql exception was thrown");
                        rows.Add(row);
                        message = ex.ToString();
                    }
                    finally
                    {
                        sqlconnection.Close();
                    }
                    break;




            }




            jss = new JavaScriptSerializer();

            var jsonObject = new JsonCRUD()
            {
                code = code,
                data = rows,
                debug = new Debug()
                {

                    data = debugData,
                    message = message
                }


            };
            return jss.Serialize(jsonObject);

        }
    }
}
