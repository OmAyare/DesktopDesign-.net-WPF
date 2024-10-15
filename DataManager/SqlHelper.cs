using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataManager
{
    public class SqlHelper
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public SqlHelper()
        {

        }
        public async Task<DataSet> ExecuteDataSet(string query, Dictionary<string, object> parameters)
        {
            DataSet result = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync();
                    SqlCommand cmd = new SqlCommand(query, con);
                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value ?? DBNull.Value);
                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public async Task<int> ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync();
                    SqlCommand cmd = new SqlCommand(query, con);
                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value ?? DBNull.Value);
                        }
                    }
                    rowsAffected = await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsAffected;
        }

    }
}
