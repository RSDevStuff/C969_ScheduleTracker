using MySql.Data.MySqlClient;

namespace C969_ScheduleTracker;

public static class DbManager
{
    private static readonly string ConnectionString =
        "server=localhost;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd";

    // We need to return a List of Dictionaries, or a List of custom objects
    public static List<Dictionary<string, object>> ExecuteQueryToList(string query)
    {
        var resultList = new List<Dictionary<string, object>>();
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            try
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.GetValue(i);
                            }
                            resultList.Add(row);
                        }
                    }
                    
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            return resultList;
        }
    }

    public static MySqlCommand GetAuthenticationString(string userName)
    {
        string query = "SELECT password FROM user WHERE username = @userName";
        MySqlCommand cmd = new MySqlCommand(query);
        cmd.Parameters.AddWithValue("@userName", userName);
        return cmd;
    }

    public static MySqlCommand GetAppointmentToday(string userId, DateTime sysDate)
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

        MySqlCommand cmd = new MySqlCommand(query);
        cmd.Parameters.AddWithValue("@userId", userId);
        cmd.Parameters.AddWithValue("@systemDate", sysDate);
        return cmd;
    }

    public static MySqlCommand GetAppointmentWeekly(string userId, DateTime sysDate)
    {
        string query = "SELECT customerName, " +
                       "DATE_FORMAT(start, '%Y-%m-%d') as Date, " +
                       "DATE_FORMAT(start, '%H:%i') as StartTime, " +
                       "DATE_FORMAT(end, '%H:%i') as EndTime, app.customerId " +
                       "FROM appointment as app " +
                       "LEFT JOIN customer as cust on app.customerId " +
                       "WHERE MONTH(app.start) = MONTH(@systemDate) " +
                       "AND YEAR(app.start) = YEAR(@systemDate) " +
                       "AND app.userId = @userId " +
                       "ORDER BY StartTime";
        MySqlCommand cmd = new MySqlCommand(query);
        cmd.Parameters.AddWithValue("@systemDate", sysDate);
        cmd.Parameters.AddWithValue("@userId", userId);
        return cmd;
    }

    public static MySqlCommand GetAppointmentAll(string userId)
    {
        string query = "SELECT cust.customerName, " +
                       "DATE_FORMAT(app.start, '%Y-%m-%d') AS Date, " +
                       "DATE_FORMAT(app.start, '%H:%i') AS StartTime, " +
                       "DATE_FORMAT(app.end, '%H:%i') AS EndTime, " +
                       "app.customerId FROM appointment AS app " +
                       "LEFT JOIN customer AS cust ON app.customerId = cust.customerId " +
                       "WHERE app.Start >= @systemDate " +
                       "AND app.userId = @userId " +
                       "ORDER BY StartTime DESC";

        MySqlCommand cmd = new MySqlCommand(query);
        cmd.Parameters.AddWithValue("@userId", userId);
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