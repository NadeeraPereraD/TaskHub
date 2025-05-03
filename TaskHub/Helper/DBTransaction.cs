using Microsoft.Data.SqlClient;
using System.Data;

namespace TaskHub.Helper
{
    public class DBTransaction
    {
        private readonly IConfiguration _configuration;

        public DBTransaction(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataSet FillDataSet(string sql, string errMsg)
        {
            DataSet dataSet = new DataSet();
            try
            {
                Connection connection = new Connection(_configuration);
                SqlConnection? con = connection.GetConnection(errMsg);
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                con.Close();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            return dataSet;
        }
    }
}
