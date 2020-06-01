using INT14078.App.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT14078.App.Common
{
    public static class ExecuteQuery<T>
    {
        public static IEnumerable<T> Execute(ConnectionInfo connectionInfo, string query, Func<SqlDataReader, T> func)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionInfo.GetConectionString()))
                using (SqlCommand comm = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    SqlDataReader sqlDataReader = comm.ExecuteReader();

                    IList<T> result = new  List<T>();
                    while (sqlDataReader.Read())
                    {
                        result.Add(func.Invoke(sqlDataReader));
                    }

                    cnn.Close();

                    return result;
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        public static void ExecuteNonQuery(ConnectionInfo connectionInfo, string query)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionInfo.GetConectionString()))
                using (SqlCommand comm = new SqlCommand(query, cnn))
                {
                    cnn.Open();

                    comm.ExecuteNonQuery();

                    cnn.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        public static void ExecuteNonQueryText(ConnectionInfo connectionInfo, string query)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionInfo.GetConectionString()))
                using (SqlCommand comm = new SqlCommand(cnn.ConnectionString))
                {
                    cnn.Open();
                    comm.CommandText = query;
                    comm.CommandType = System.Data.CommandType.Text;
                    comm.ExecuteNonQuery();

                    cnn.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }
    }
}
