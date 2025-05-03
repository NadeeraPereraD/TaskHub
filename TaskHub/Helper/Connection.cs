using Microsoft.Data.SqlClient;

namespace TaskHub.Helper
{
    public class Connection
    {
        private readonly IConfiguration _configuration;

        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection? GetConnection(string errMsg)
        {
            SqlConnection con = null;
            try
            {
                string? conString = _configuration.GetConnectionString("DefaultConnection");

                if(string.IsNullOrEmpty(conString))
                {
                    throw new Exception("Connection String is null or empty!!!...");
                }
                else
                {
                    con = new SqlConnection(conString);
                    if(con == null)
                    {
                        throw new Exception("Connection is not found. Cannot create database access.");
                    }
                    else
                    {
                        if(con.State != System.Data.ConnectionState.Open)
                        {
                            con.Open();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            return con;
        }
    }
}
