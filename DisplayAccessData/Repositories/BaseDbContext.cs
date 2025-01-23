using System.Data.OleDb;

namespace DisplayAccessData.Repositories
{
    public class BaseDbContext
    {
        public static string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Projects\DisplayAccessData\DisplayAccessData\Database\Reservation Booking System.mdb;Persist Security Info=False;";
    }
}
