using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class JobsDAO
    {
        private static DataBase _database;

        public List<JobsDTO> GetJobs()
        {
            List<JobsDTO> listJobs = new List<JobsDTO>();

            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();

            _database = new DataBase();

            // Verify DB connection
            if (_database.IsConnected() == false)
            {
                _database.Connect();
            }

            cmd.CommandText = "SELECT job.*, clt.ID as 'IDCLIENT', clt.NAME as 'NAMECLIENT', clt.EMAIL	as 'EMAILCLIENT', clt.ADDRESS as 'ADDRESSCLIENT' FROM [i-TechSolutions].dbo.JOBS job INNER JOIN [i-TechSolutions].dbo.CLIENTS clt on job.CLIENT = clt.ID";
            cmd.Connection = _database.Connection;

            dr = cmd.ExecuteReader();

            listJobs = ConvertTo_JobsList(dr);

            dr.Close();
            cmd.Dispose();
            return listJobs;
        }

        public JobsDTO GetJob(int _jobID)
        {
            JobsDTO Job = new JobsDTO();

            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();

            _database = new DataBase();

            // Verify DB connection
            if (_database.IsConnected() == false)
            {
                _database.Connect();
            }

            StringBuilder strCommand = new StringBuilder();
            strCommand.Append("SELECT job.*");
            strCommand.Append(", clt.ID as 'IDCLIENT', clt.NAME as 'NAMECLIENT', clt.EMAIL	as 'EMAILCLIENT'");
            strCommand.Append(", clt.ADDRESS as 'ADDRESSCLIENT'");
            strCommand.Append(" FROM [i-TechSolutions].dbo.JOBS job");
            strCommand.Append(" INNER JOIN [i-TechSolutions].dbo.CLIENTS clt on job.CLIENT = clt.ID");
            strCommand.Append(" WHERE job.ID = " + _jobID.ToString());

            cmd.CommandText = strCommand.ToString();
            cmd.Connection = _database.Connection;

            dr = cmd.ExecuteReader();

            Job = ConvertTo_JobsList(dr).FirstOrDefault();

            dr.Close();
            cmd.Dispose();
            return Job;
        }

        public Boolean InsertJob(JobsDTO job)
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
            strCommand.Append("INSERT INTO dbo.JOBS");
            strCommand.Append("(CLIENT, DATE, DESCRIPTION, PRICE, DATEFINISH, FINISHED)");
            strCommand.Append("VALUES(");
            strCommand.Append("'" + job.Client.Id.ToString());
            strCommand.Append("', '" + job.Date.ToString("dd/MM/yyyy"));
            strCommand.Append("', '" + job.Description);
            strCommand.Append("', '" + job.Price.ToString());
            strCommand.Append("', '" + job.DateFinish.ToString("dd/MM/yyyy"));

            if (job.Finished)
            {
                strCommand.Append("', 'Y");
            }
            else
            {
                strCommand.Append("', 'N");
            }
            
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

        private List<JobsDTO> ConvertTo_JobsList(SqlDataReader dr)
        {
            List<JobsDTO> listJobs = new List<JobsDTO>();

            if (dr != null)
            {
                JobsDTO jobs;
                ClientsDTO client;
                while (dr.Read())
                {
                    jobs = new JobsDTO();
                    client = new ClientsDTO();

                    jobs.Id = Convert.ToInt32(dr["ID"].ToString());
                    jobs.Date = Convert.ToDateTime(dr["DATE"].ToString());
                    jobs.Description = dr["DESCRIPTION"].ToString();
                    jobs.Price = Convert.ToDecimal(dr["PRICE"].ToString());

                    client.Id = Convert.ToInt32(dr["IDCLIENT"].ToString());
                    client.Name = dr["NAMECLIENT"].ToString();
                    client.Email = dr["EMAILCLIENT"].ToString();
                    client.Address = dr["ADDRESSCLIENT"].ToString();
                    jobs.Client = client;

                    listJobs.Add(jobs);
                }
            }

            return listJobs;
        }
    }
}
