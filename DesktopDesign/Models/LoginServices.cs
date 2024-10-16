using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDesign.Models
{
    public class LoginServices
    {
        SqlConnection ObjSqlConnection;
        SqlCommand ObjSqlCommand;

        public LoginServices()
        {
            ObjSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            ObjSqlCommand = new SqlCommand();
            ObjSqlCommand.Connection = ObjSqlConnection;
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;    
        }


        public bool CheckLogin(LoginModels loginModels)
        {
            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "CheckLogin";
                ObjSqlCommand.Parameters.AddWithValue("@UserName", loginModels.UserName);
                ObjSqlCommand.Parameters.AddWithValue("@Password", loginModels.PassWord);
                ObjSqlConnection.Open();

                int count = Convert.ToInt32(ObjSqlCommand.ExecuteScalar());

                if (count == 1)
                {
                    Details details = new Details();
                    details.Show();
                    this.ObjSqlConnection.Close();

                }


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
