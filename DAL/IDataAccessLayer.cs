using System.Data;
using Microsoft.Data.SqlClient;

namespace MegaMindsTask.DAL
{
    public interface IDataAccessLayer
    {
        int Execute(string SqlQuery, SqlParameter[] param, CommandType commandType = CommandType.StoredProcedure);
        DataTable Get(string SqlQuery,CommandType commandType = CommandType.StoredProcedure);
        DataTable Get(string SqlQuery, SqlParameter[] param, CommandType commandType = CommandType.StoredProcedure);
    }
}
