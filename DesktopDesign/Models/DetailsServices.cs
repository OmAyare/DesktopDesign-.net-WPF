using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDesign.Models
{
    public class DetailsServices
    {
        SqlConnection ObjSqlConnection;
        SqlCommand ObjSqlCommand;

        public DetailsServices()
        {
            ObjSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            ObjSqlCommand = new SqlCommand();
            ObjSqlCommand.Connection = ObjSqlConnection;
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;

        }

        public bool Add(DetailsModel objNewemployee)
        {
            bool IsAdded = false;
            try
            {
                string fullName = $"{objNewemployee.FirstName} {objNewemployee.LastName}";

                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "_InsertDetails";
                ObjSqlCommand.Parameters.AddWithValue("@Name", fullName);
                ObjSqlCommand.Parameters.AddWithValue("@Company_Name", objNewemployee.Company_Name);
                ObjSqlCommand.Parameters.AddWithValue("@Phone_No",  objNewemployee.Phone_No);
                ObjSqlCommand.Parameters.AddWithValue("@Email",  objNewemployee.Email);
                ObjSqlCommand.Parameters.AddWithValue("@Address",  objNewemployee.Address);
                ObjSqlCommand.Parameters.AddWithValue("@city",  objNewemployee.city);
                ObjSqlCommand.Parameters.AddWithValue("@state",  objNewemployee.state);

                ObjSqlConnection.Open();
                int NoofRowsAffected = ObjSqlCommand.ExecuteNonQuery();
                IsAdded = NoofRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }


            return true;
        }
    }
}
