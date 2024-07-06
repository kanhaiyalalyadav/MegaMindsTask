using MegaMindsTask.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MegaMindsTask.DAL
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private readonly string ConnectionString;
        public DataAccessLayer(ConnectionHelper connection)
        {
            ConnectionString = connection.Default;
        }
        public int Execute(string SqlQuery, SqlParameter[] param, CommandType commandType = CommandType.StoredProcedure)
        {
            int i = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(SqlQuery, con);
                    cmd.CommandType = commandType;
                    foreach (var p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                    con.Open();

                    i = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            return i;
        }

        public DataTable Get(string SqlQuery, CommandType commandType = CommandType.StoredProcedure)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, con);
                cmd.CommandType = commandType;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            return dt;
        }

        public DataTable Get(string SqlQuery, SqlParameter[] param, CommandType commandType = CommandType.StoredProcedure)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, con);
                    cmd.CommandType = commandType;
                    foreach (var p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
    }
}
