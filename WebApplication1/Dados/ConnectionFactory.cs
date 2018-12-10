using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Dados
{
    public class ConnectionFactory
    {
        public static IDbConnection Create(string cnxString)
        {
            return new SqlConnection(cnxString);
        }
    }
}
