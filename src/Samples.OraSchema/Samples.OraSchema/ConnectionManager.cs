using System;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace Samples.OraSchema
{
    internal sealed class ConnectionManager
    {
        static OracleConnection connection = null;
        internal static OracleConnection OpenAndGetConnection(string connectionString)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            return connection;
        }
        internal static void CloseConnection()
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection = null;
                }
            }
        }
    }
}
