using DisplayAccessData.Models;
using System.Data.OleDb;

namespace DisplayAccessData.Repositories
{
    public class PLCControlDbContext : BaseDbContext
    {
        public static List<PLCControl> GetAll()
        {
            List<PLCControl> models = new List<PLCControl>();

            OleDbConnection oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = connString;
            oleDbConnection.Open();
            string strSQL = "SELECT * FROM PLCControl";
            OleDbDataReader reader = null;
            OleDbCommand command = new OleDbCommand(strSQL, oleDbConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                PLCControl model = new PLCControl();
                model.DeviceName = reader[0].ToString();
                model.Gateway = reader[1].ToString();
                model.CommandTag = reader[2].ToString();
                model.StatusTag = reader[3].ToString();
                model.DataTag = reader[4].ToString();
                model.Download = Convert.ToBoolean(reader["Download"]);
                model.PLCType = reader[6].ToString();
                model.CPName = reader[7].ToString();
                model.Message = reader[8].ToString();
                model.TimeSync = Convert.ToBoolean(reader[9]);
                models.Add(model);
            }
            oleDbConnection.Close();
            return models;
        }
    }
}
