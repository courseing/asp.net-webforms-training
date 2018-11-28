using ASPNetWebForms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASPNetWebForms.DAL
{
    public class ProductDAL
    {

        public string Name { get; set; }
        public static string ConnectionString { get; set; }

        public DataSet GetProducts()
        {
            string Query = "select Id,Name from Products";
            SQLManager manager = new SQLManager();
            return manager.GetDataSet(Query);
        }

        public bool UpdateProduct(Product product)
        {
            bool isSuccess;
            List<ProcParameters> procParams = new List<ProcParameters>();
            procParams.Add(new ProcParameters("@ProductId", product.Id.ToString(), DbType.Int32, ParameterDirection.Input));
            procParams.Add(new ProcParameters("@Name", product.Name, DbType.String, ParameterDirection.Input));

            SQLManager manager = new SQLManager();
            isSuccess = manager.UpdateRecord("Products_CRUD", procParams);

            return isSuccess;
        }

        public void UpdateRecord()
        {
            //DataSet ds;
            //using (SqlConnection conn = new SqlConnection(ConnectionString))
            //{
            //    //SqlCommand cmd = new SqlCommand("select * from Products", conn);
            //    SqlDataAdapter sqlda = new SqlDataAdapter("select * from Products", conn);
            //    ds = new DataSet();
            //    sqlda.Fill(ds);
            //}

            DataSet ds;
            SqlCommandBuilder cmdBuilder;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //SqlCommand cmd = new SqlCommand("select * from Products", conn);
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from Persons", conn);
                cmdBuilder = new SqlCommandBuilder(sqlda);

                ds = new DataSet();
                sqlda.Fill(ds,"Persons");

                ds.Tables[0].Rows[0]["Name"] = "Jack1";
                sqlda.Update(ds, ds.Tables["Persons"].ToString());
            }
        }
        public void UpdateRowsAtOnceSQLDataAdapter()
        {

            List<Product> prd = new List<Product>();
            prd[0].Name = "";

            DataSet ds;
            SqlCommandBuilder cmdBuilder;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //SqlCommand cmd = new SqlCommand("select * from Products", conn);
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from Products", conn);
                cmdBuilder = new SqlCommandBuilder(sqlda);

                ds = new DataSet();
                sqlda.Fill(ds);

                //ds.Tables[0].Rows[0]["Name"] = "Jack1";
                DataRow[] dr = ds.Tables[0].Select("Name='Tabs'");

                foreach(DataRow dr1 in dr)
                {
                    dr1["Name"] = "Tab1";
                }

                sqlda.Update(dr);
            }
        }
        static ProductDAL()
        {
            ConnectionString = "Data Source = localhost; Initial Catalog = WebAuth; Integrated Security = True; Connect Timeout = 15; Encrypt = False; Packet Size = 4096";
        }
        public bool InsertData()
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                DataSet dataSet = new DataSet();
                SqlDataAdapter dataAdapter;

                var sqlQuery = "select * from Products";
                dataAdapter = new SqlDataAdapter(sqlQuery, conn);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                var newRow = dataSet.Tables[0].NewRow();
                newRow["Name"] = "Mobile";
                dataSet.Tables[0].Rows.Add(newRow);

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataSet);
            }
            return true;
        }
        public void GetResultUsingSelectStmt()
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                // create and open a connection object
                conn = new
                    SqlConnection(ConnectionString);
                conn.Open();

                // 1. create a command object identifying
                // the stored procedure
                SqlCommand cmd = new SqlCommand(
                    "GetAProduct", conn);

                // 2. set the command object so it knows
                // to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // execute the command
                rdr = cmd.ExecuteReader();

                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    Name = rdr["Name"].ToString();
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
        }
        public void GetResultUsingProc()
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                // create and open a connection object
                conn = new
                    SqlConnection(ConnectionString);
                conn.Open();

                // 1. create a command object identifying
                // the stored procedure
                SqlCommand cmd = new SqlCommand(
                    "GetProducts", conn);

                // 2. set the command object so it knows
                // to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // execute the command
                rdr = cmd.ExecuteReader();

                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    Name = rdr["Name"].ToString() ;
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
        }
        public void GetResultUsingProcParam()
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            // typically obtained from user
            // input, but we take a short cut
            int Id = 1;


            try
            {
                // create and open a connection object
                conn = new
                    SqlConnection(ConnectionString);
                conn.Open();

                // 1. create a command object identifying
                // the stored procedure
                SqlCommand cmd = new SqlCommand(
                    "GetAProduct", conn);

                // 2. set the command object so it knows
                // to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which
                // will be passed to the stored procedure
                //-----------------------------
                //cmd.Parameters.Add(new SqlParameter("@Id", Id));

                //-----------------------------
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Id";
                param.Value = Id;
                cmd.Parameters.Add(param);
                //param.Direction = ParameterDirection.ReturnValue;

                // execute the command
                rdr = cmd.ExecuteReader();

                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    Name = rdr["Name"].ToString();
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
        }
        public bool UpdateData()
        {
            SqlConnection cn = new SqlConnection();
            DataSet ProductsDataSet = new DataSet();
            SqlDataAdapter da;
            SqlCommandBuilder cmdBuilder;

            //Set the connection string of the SqlConnection object to connect
            //to the SQL Server database in which you created the sample
            //table.
            cn.ConnectionString = ConnectionString;
            cn.Open();

            //Initialize the SqlDataAdapter object by specifying a Select command 
            //that retrieves data from the sample table.
            da = new SqlDataAdapter("select * from Products", cn);

            //Initialize the SqlCommandBuilder object to automatically generate and initialize
            //the UpdateCommand, InsertCommand, and DeleteCommand properties of the SqlDataAdapter.
            cmdBuilder = new SqlCommandBuilder(da);

            //Populate the DataSet by running the Fill method of the SqlDataAdapter.
            da.Fill(ProductsDataSet, "Products");

            //Display the Update, Insert, and Delete commands that were automatically generated
            //by the SqlCommandBuilder object.
            Console.WriteLine("Update command Generated by the Command Builder : ");
            Console.WriteLine("==================================================");
            Console.WriteLine(cmdBuilder.GetUpdateCommand().CommandText);
            Console.WriteLine("         ");

            Console.WriteLine("Insert command Generated by the Command Builder : ");
            Console.WriteLine("==================================================");
            Console.WriteLine(cmdBuilder.GetInsertCommand().CommandText);
            Console.WriteLine("         ");

            Console.WriteLine("Delete command Generated by the Command Builder : ");
            Console.WriteLine("==================================================");
            Console.WriteLine(cmdBuilder.GetDeleteCommand().CommandText);
            Console.WriteLine("         ");

            //Write out the value in the CustName field before updating the data using the DataSet.
            //Console.WriteLine("Product Name before Update : " + ProductsDataSet.Tables["Products"].Rows[0]["Name"]);

            //Modify the value of the CustName field.

            //ProductsDataSet.Tables["Products"].Rows[0]["Name"] = "Jack";
            DataRow dr;
            dr = ProductsDataSet.Tables[0].NewRow();
            dr["Name"] = "Mobile";




            //Post the data modification to the database.
            da.Update(ProductsDataSet, "Products");

            //Console.WriteLine("Product Name updated successfully");

            //Close the database connection.
            cn.Close();

            //Pause
            //Console.ReadLine();
            return true;
        }
        public bool GetDataSet()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select UserName, First Name,LastName,Location FROM Users", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                // gvUserInfo.DataSource = ds;
                //gvUserInfo.DataBind();
            }
            return true;
        }
        public bool GetDataTable()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select UserName, First Name,LastName,Location FROM Users", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                // gvUserInfo.DataSource = dt;
                //gvUserInfo.DataBind();
            }
            return true;
        }
        public  Product GetResults()
        {
            //string Name;
            Product prd = new Product(); 

            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=WebAuth;Integrated Security=True;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
            {
                //SqlCommand command = new SqlCommand(
                //  "SELECT CategoryID, CategoryName FROM dbo.Categories;" +
                //  "SELECT EmployeeID, LastName FROM dbo.Employees",

                SqlCommand command = new SqlCommand("GetResultsWhatEver",connection);
                //command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                //  reader["Id"]
                prd.Name = reader["name"].ToString();

                    while (reader.Read())
                    {
                        prd.Name = reader["Name"].ToString();
                        //Console.WriteLine("\t{0}\t{1}", reader.GetInt32(0),reader.GetString(1));
                    }

                reader.NextResult();
                    while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}", reader.GetInt32(0),
                        reader.GetString(1));
                }

            }
            return prd;
        }
        public bool GetResult()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=WebAuth;Integrated Security=True;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT CategoryID, CategoryName FROM dbo.Categories;" +
                  "SELECT EmployeeID, LastName FROM dbo.Employees",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}", reader.GetInt32(0),
                        reader.GetString(1));
                }
            }
            return true;
        }
        public bool AddRecord()
        {
            bool isSuccess = true;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
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