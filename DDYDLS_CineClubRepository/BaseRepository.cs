using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ADO_Toolbox;

namespace YraesportDAL.Repository
{
    public class BaseRepository
    {
        internal  Connection _connection;

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
