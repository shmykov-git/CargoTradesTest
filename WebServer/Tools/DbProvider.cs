using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace WebServer.Tools
{
    public class DbProvider
    {
        private string ConnectionString => "Data Source=localhost;Initial Catalog=CargoTrades;Integrated Security=True";

        public string GetData()
        {
            var sql = @"SELECT Data FROM Datas WHERE ID = 1";
            var tb = GetDataTable(sql);
            if (tb.Rows.Any())
                return tb.Rows[0][0].ToString();

            return null;
        }

        public void SaveData(string data)
        {
            var sql = @"

IF EXISTS(SELECT * FROM Datas WHERE ID = 1)
BEGIN
    UPDATE Datas SET Data = @Data WHERE ID = 1
END
ELSE
BEGIN
    INSERT INTO Datas (Data) VALUES (@Data)
END

";
            ExecuteNonQuery(sql, new SqlParameter("Data", SqlDbType.VarChar) {Value = data});
        }

        private void ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
            }
        }

        private DataTable GetDataTable(string sql)
        {
            var dt = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
    }
}
