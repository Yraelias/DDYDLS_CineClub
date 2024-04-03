using ADO_Toolbox;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DDYDLS_CineClubDAL.Repository
{
    public class BaseRepository
    {
        internal Connection _connection;

        IConfiguration _config;
        public SqlConnection Connection()
        {
            return new SqlConnection(_config.GetConnectionString("defaultConnection"));
        }

        public BaseRepository(IConfiguration config)
        {

            _config = config;
            _connection = new Connection(config.GetConnectionString("defaultConnection"));
        }
    }
}
