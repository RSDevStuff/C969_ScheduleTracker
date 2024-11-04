using MySql.Data.MySqlClient;

namespace C969_ScheduleTracker;

public static class DbManager
{
    private static readonly string ConnectionString =
        "server=localhost;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd";

    public static MySqlDataReader ExecuteQuery(string query)
    {
        List<Object> resultList = new List<object>();
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            try
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
            }
            catch (MySqlException e)
            { 
                Console.WriteLine($"Error: {e.Message}");
            }

            return null;
        }
    }

    public static MySqlCommand GetAuthenticationString(string userName)
    {
        string query = "SELECT password FROM user WHERE username = @userName";
        MySqlCommand cmd = new MySqlCommand(query);
        cmd.Parameters.AddWithValue("@userName", userName);
        return cmd;
    }

    public static MySqlCommand GetAppointmentInfo(string userId, DateTime sysDate)
    {
        string query = "SELECT customerName," +
                       " DATE_FORMAT(start, '%Y-%m-%d') as Date" +
                       ", DATE_FORMAT(start, '%H:%i') as StartTime," +
                       " DATE_FORMAT(end, '%H:%i') as EndTime," +
                       " app.customerId FROM appointment as app" +
                       "LEFT JOIN customer as cust on app.customerId" +
                       "WHERE Date = @systemDate " +
                       "AND app.userId = @userId" +
                       "ORDER BY StartTime";

        MySqlCommand cmd = new MySqlCommand( query );
        cmd.Parameters.AddWithValue("@userId", userId);
        cmd.Parameters.AddWithValue("@systemDate", sysDate);
        return cmd;
    }

    public static MySqlCommand GetCustomerInfo(string custId)
    {
        string query =
            "SELECT cust.customerId," +
            "cust.customerName, " +
            "addr.address," +
            "addr.phone," +
            "ci.city," +
            "co.country " +
            "FROM customer as cust " +
            "LEFT JOIN address as addr " +
            "on cust.addressId = addr.addressId " +
            "LEFT JOIN city as ci ON ci.cityId = addr.cityId " +
            "LEFT JOIN country as co ON co.countryId = ci.countryId";

        MySqlCommand cmd = new MySqlCommand(query);
        return cmd;
    }
}