
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV2
{
    public class Provider
    {
        private static Provider _Instance;
        private string s;
        public static Provider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Provider();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }
        private Provider()
        {
            s = @"Data Source=LAPTOP-43NJDB10;Initial Catalog=demoketnoicsdl;Integrated Security=True";
        }
        public bool Execute(string query)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public DataTable Getrecord(string q)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cnn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand(q, cnn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cnn.Open();
                    da.Fill(dt);
                    cnn.Close();
                    return dt;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}

