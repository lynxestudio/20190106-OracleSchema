using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Samples.OraSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = null,
                      password = null,
                      dataSource = null;
            Console.WriteLine(" Oracle schema example v1.0");
            Console.WriteLine("=======================================\n");
            username = Util.Prompt(" Enter username: ");
            password = Util.Prompt(" Enter password: ");
            dataSource = Util.Prompt(" Enter DataSource: ");
            try
            {
                OracleConnectionStringBuilder strBuilder = new OracleConnectionStringBuilder();
                strBuilder.UserID = username;
                strBuilder.Password = password;
                strBuilder.DataSource = dataSource;
                OracleConnection conn = ConnectionManager.OpenAndGetConnection(strBuilder.ConnectionString);
                var dt = new DataTable();
                OracleCommand cmd = new OracleCommand("select object_name, object_type from user_objects", conn);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(dt);
                Console.WriteLine(" Getting schema objects...");
                Util.PrintDataTable(dt);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            Console.WriteLine();
            Util.Prompt("Press ENTER to finish.");
        }
    }
}
