using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class ClientsDAO
    {
        private static DataBase _database;

        public List<ClientsDTO> GetClients()
        {
            List<ClientsDTO> listClients = new List<ClientsDTO>();

            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();

            _database = new DataBase();

            // Verify DB connection
            if (_database.IsConnected() == false)
            {
                _database.Connect();
            }

            cmd.CommandText = "SELECT * FROM dbo.CLIENTS";
            cmd.Connection = _database.Connection;

            dr = cmd.ExecuteReader();

            listClients = ConvertTo_ClientsList(dr);

            dr.Close();
            cmd.Dispose();
            return listClients;
        }

        public ClientsDTO GetClient(int _clientID)
        {
            ClientsDTO Client = new ClientsDTO();

            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();

            _database = new DataBase();

            // Verify DB connection
            if (_database.IsConnected() == false)
            {
                _database.Connect();
            }

            cmd.CommandText = "SELECT * FROM dbo.CLIENTS WHERE ID = " + _clientID.ToString().Trim();
            cmd.Connection = _database.Connection;

            dr = cmd.ExecuteReader();

            Client = ConvertTo_ClientsList(dr).FirstOrDefault();

            dr.Close();
            cmd.Dispose();
            return Client;
        }

        private List<ClientsDTO> ConvertTo_ClientsList(SqlDataReader dr)
        {
            List<ClientsDTO> listClients = new List<ClientsDTO>();

            if (dr != null)
            {
                ClientsDTO client;
                while (dr.Read())
                {
                    client = new ClientsDTO();

                    client.Id = Convert.ToInt32(dr["ID"].ToString());
                    client.Name = dr["NAME"].ToString();
                    client.Email = dr["EMAIL"].ToString();
                    client.Address = dr["ADDRESS"].ToString();

                    listClients.Add(client);
                }
            }

            return listClients;
        }

        public Boolean InsertClient(ClientsDTO client)
        {
            SqlCommand cmd = new SqlCommand();
            Boolean result = false;

            _database = new DataBase();

            // Verify DB connection
            if (_database.IsConnected() == false)
            {
                _database.Connect();
            }

            StringBuilder strCommand = new StringBuilder();
            strCommand.Append("INSERT INTO dbo.CLIENTS");
            strCommand.Append("(NAME, EMAIL, ADDRESS)");
            strCommand.Append("VALUES(");
            strCommand.Append("'" + client.Name);
            strCommand.Append("', '" + client.Email);
            strCommand.Append("', '" + client.Address);
            strCommand.Append("')");

            cmd.CommandText = strCommand.ToString();
            cmd.Connection = _database.Connection;

            try
            {
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch { }

            cmd.Dispose();
            return result;
        }
    }
}
