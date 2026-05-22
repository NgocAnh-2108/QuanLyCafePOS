using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCafePOS.Data
{
    public static class Db
    {
        public static string ConnectionString
        {
            get
            {
                ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["QuanLyCafe"];
                if (cs != null && !string.IsNullOrWhiteSpace(cs.ConnectionString))
                {
                    return cs.ConnectionString;
                }

                return @"Data Source=.;Initial Catalog=QuanLyCafeDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True";
            }
        }

        public static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        public static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        public static SqlConnection Open()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            return con;
        }

        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                con.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static string TestConnection()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
