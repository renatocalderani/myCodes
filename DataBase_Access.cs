using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAO
{
    public class DataBase
    {
        private string _connString;
        public String ConnString
        {
            set { _connString = value; }
            get { return _connString; }
        }

        private static string _error;
        public static string Error
        {
            set { _error = value; }
            get { return _error; }
        }

        private static SqlConnection _connection;
        public SqlConnection Connection
        {
            set 
            {
                _connection = value;
            }
            get 
            {
                return _connection;
            }
        }

        public Boolean Connect()
        {
            Boolean result = false;
            ConnString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

            if (String.IsNullOrEmpty(ConnString) == false)
            {
                try
                {
                    Connection = new SqlConnection(ConnString);
                    Connection.Open();
                    result = true;
                }
                catch (Exception exc)
                {
                    Error = exc.Message;
                    result = false;
                }
            }
            else 
            {
                result = false;
            }
            return result;
        }

        public Boolean IsConnected() 
        {
            Boolean connected = false;

            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                connected = true;
            }

            return connected;
        }
    }
}
