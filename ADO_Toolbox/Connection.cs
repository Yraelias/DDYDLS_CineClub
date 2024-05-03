using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADO_Toolbox
{
    public class Connection
    {
        internal string connectionString { get; set; }
        public Connection(string ConnexionString)
        {
            connectionString = ConnexionString;
        }
        public object ExecuteScalar(Command Mcmd)
        {
            using (SqlConnection c = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(Mcmd, c))
                {
                    c.Open();
                    object t = cmd.ExecuteScalar();
                    return (t is DBNull) ? null : t;
                }
            }

        }


        public IEnumerable<T> ExecuteReader<T>(Command Command, Func<SqlDataReader, T> convert)
        {
            using (SqlConnection c = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(Command, c))
                {
                    c.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return convert(dr);
                        }
                    }
                }
            }

        }



        public IEnumerable<T> ExecuteReader<T>(Command Command)
            where T : new()
        {
            using (SqlConnection c = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(Command, c))
                {
                    c.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        System.Reflection.PropertyInfo[] props = typeof(T).GetProperties();

                        while (dr.Read())
                        {
                            T elem = (T)Activator.CreateInstance(typeof(T));

                            foreach (System.Reflection.PropertyInfo property in props)
                            {
                                property.SetValue(elem, dr[property.Name]);
                            }

                            yield return elem;
                        }
                    }
                }
            }

        }



        public int ExecuteNonQuery(Command Command)
        {
            using (SqlConnection c = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(Command, c))
                {
                    c.Open();
                    int i = cmd.ExecuteNonQuery();
                    return i;
                }
            }
        }



        private SqlConnection CreateConnection()
        {
            SqlConnection c = new SqlConnection();
            c.ConnectionString = connectionString;
            return c;
        }

        public SqlCommand CreateCommand(Command Mcmd, SqlConnection connection)
        {
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd = connection.CreateCommand();
            SqlCmd.CommandText = Mcmd.Query;
            SqlCmd.CommandType = Mcmd.IsStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            if (Mcmd.Parameters != null)
            {
                foreach (KeyValuePair<string, object> sp in Mcmd.Parameters)
                {
                    SqlParameter parameter = SqlCmd.CreateParameter();
                    parameter.ParameterName = sp.Key;
                    parameter.Value = sp.Value;

                    SqlCmd.Parameters.Add(parameter);
                }
            }
            return SqlCmd;
        }
    }
}
