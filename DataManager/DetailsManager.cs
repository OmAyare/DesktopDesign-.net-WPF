using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class DetailsManager
    {
        private SqlHelper dbHelper = new SqlHelper();

        public async Task<bool> AddEmployee( DetailsModel employee)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@Name", employee.Name);
                parameters.Add("@Company_Name", employee.Company_Name);
                parameters.Add("@Phone_No", Convert.ToInt32(employee.Phone_No));
                parameters.Add("@Email", employee.Email);
                parameters.Add("@Address", employee.Address);
                parameters.Add("@city", employee.city);
                parameters.Add("@state", employee.state);

                int rowsInserted = await dbHelper.ExecuteNonQuery(@"INSERT INTO Details (Name, Company_Name, Phone_No, Email, Address, city, state) " +
                               "VALUES (@Name, @Company_Name, @Phone_No, @Email, @Address, @city, @state)", parameters);

            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }
    }
}
