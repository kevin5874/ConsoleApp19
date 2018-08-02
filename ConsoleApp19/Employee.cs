using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Employee
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string ID { get; set; }
        public string EmpType { get; set; }
        public string payType { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public Employee (string FName, string LName, string ID, string EmpType, string payType, string Phone, DateTime DOB)
        {
            this.FName = FName;
            this.LName = LName;
            this.ID = ID;
            this.EmpType = EmpType;
            this.payType = payType;
            this.Phone = Phone;
            this.DOB = DOB;
        }
        public void ToDB()//adding employees to DB
        {
            string connectionString = @"Data Source=DESKTOP-1N6P132;Initial Catalog=EmpTest;Integrated Security=True";
            string queryString = @"INSERT INTO Employees (FName, LName, ID, EmpType, PayType, Phone, DOB) VALUES
                                      (@FName, @LName, @ID, @EmpType, @PayType, @Phone, @DOB)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.Add("@FName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@LName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ID", SqlDbType.NVarChar);
                cmd.Parameters.Add("@EmpType", SqlDbType.NVarChar);
                cmd.Parameters.Add("@PayType", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                cmd.Parameters.Add("@DOB", SqlDbType.Date);
                cmd.Parameters["@FName"].Value = FName;
                cmd.Parameters["@LName"].Value = LName;
                cmd.Parameters["@ID"].Value = ID;
                cmd.Parameters["@EmpType"].Value = EmpType;
                cmd.Parameters["@PayType"].Value = payType;
                cmd.Parameters["@Phone"].Value = Phone;
                cmd.Parameters["@DOB"].Value = DOB;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
