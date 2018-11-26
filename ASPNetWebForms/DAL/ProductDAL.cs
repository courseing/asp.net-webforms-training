using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASPNetWebForms.DAL
{
    public class ProductDAL
    {
        public string Name { get; set; }

        public bool AddRecord()
        {
            bool isSuccess = true;
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=WebAuth;Integrated Security=True;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into Products(Name) values('" + Name + "')";
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected < 1)
                    {
                        throw new Exception("Could not save the data");
                    }

                }
                catch (Exception ex)
                {
                    //Write exception to log
                    isSuccess = false;
                }
                finally
                {
                    conn.Close();
                }
                return isSuccess;
            }
        }
    }
}