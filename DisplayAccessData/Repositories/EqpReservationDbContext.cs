using DisplayAccessData.Models;
using System.Data.OleDb;

namespace DisplayAccessData.Repositories
{
    public class EqpReservationDbContext : BaseDbContext
    {
        public static List<EqpReservation> GetAll()
        {            
            List<EqpReservation> models = new List<EqpReservation>();

            OleDbConnection oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = connString;
            string strSQL = "SELECT * FROM EqpReservations";
            OleDbDataReader reader = null;
            OleDbCommand command = new OleDbCommand(strSQL, oleDbConnection);
            oleDbConnection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                EqpReservation model = new EqpReservation();
                model.BookSNo = reader[0].ToString();
                model.RecordSource = reader[1].ToString();
                model.Equipment = reader[2].ToString();
                model.ActState = Convert.ToBoolean(reader[3]);
                model.ActTime = Convert.ToDateTime(reader[4]);
                model.DeactTime = Convert.ToDateTime(reader["DeactTime"]);
                model.CardEnable = Convert.ToBoolean(reader[6]);
                model.Init = Convert.ToBoolean(reader[7]);
                models.Add(model);
            }
            oleDbConnection.Close();
            return models;
        }
    }
}
