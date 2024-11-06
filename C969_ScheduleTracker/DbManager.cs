using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace C969_ScheduleTracker;

public static class DbManager
{
    private static readonly string ConnectionString =
        "server=localhost;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!";

    // We need to return a List of Dictionaries, or a List of custom objects
    //public static List<Dictionary<string, object>> ExecuteQueryToList(MySqlCommand cmd)
    //{
    //    var resultList = new List<Dictionary<string, object>>();
    //    using (MySqlConnection connection = new MySqlConnection(ConnectionString))
    //    {
    //        try
    //        {
    //            connection.Open();
    //            cmd.Connection = connection;

    //            using (MySqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                while (reader.Read())
    //                {
    //                    var row = new Dictionary<string, object>();
    //                    for (int i = 0; i < reader.FieldCount; i++)
    //                    {
    //                        row[reader.GetName(i)] = reader.GetValue(i);
    //                    }
    //                    resultList.Add(row);
    //                }
    //            }
    //        }
    //        catch (MySqlException e)
    //        {
    //            MessageBox.Show($"Error: {e.Message}");
    //        }

    //        return resultList;
    //    }
    //}

    //Custom object implementation
    //Requires an empty constructor for each custom object
    public static BindingList<T> ExecuteQueryToBindingList<T>(MySqlCommand cmd) where T : new()
    {
        var resultList = new BindingList<T>();
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            //try
            //{
                connection.Open();
                cmd.Connection = connection;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // We use GetProperies to pull properties from custom object
                    var properties = typeof(T).GetProperties();
                    while (reader.Read())
                    {
                        // Create an instance of the custom object for each row...
                        T item = new T();
                        // For each property, we'll check if the column matching it is null,
                        // If it isn't, we'll set the item's property of that name to the value of it
                        foreach (var prop in properties)
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                            {
                                prop.SetValue(item, reader.GetValue(reader.GetOrdinal(prop.Name)));
                            }
                        }
                        resultList.Add(item);
                }
                //}
            }
            //catch (MySqlException e)
           // {
            //    MessageBox.Show($"Error: {e.Message}");
            //}

            return resultList;
        }
    }

    public static int ExecuteModification(string query)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            try
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return -1;
            }
        }
    }

    public static MySqlCommand GetAuthenticationString(string userName)
    {
        string query = "SELECT userId, userName, password FROM user WHERE username = @userName";
        MySqlCommand cmd = new MySqlCommand(query);
        cmd.Parameters.AddWithValue("@userName", userName);
        return cmd;
    }


    public static MySqlCommand GetAppointmentAll()
    {
        string query = "SELECT cust.customerName as Customer, " +
                       "app.start AS Date, " +
                       "app.start AS Start, " +
                       "app.end AS End, " +
                       "app.type as Type, " +
                       "app.userId as UserId, " +
                       "app.customerId as CustomerId " +
                       "FROM appointment AS app " +
                       "LEFT JOIN customer AS cust ON app.customerId = cust.customerId " +
                       "ORDER BY app.start DESC";

        MySqlCommand cmd = new MySqlCommand(query);
        return cmd;
    }

    public static MySqlCommand GetCustomerAll()
    {
        string query =
            "SELECT cust.customerId as CustomerId," +
            "cust.customerName as Name, " +
            "addr.address as Address," +
            "addr.phone as Phone," +
            "ci.city as City," +
            "co.country as Country " +
            "FROM customer as cust " +
            "LEFT JOIN address as addr " +
            "on cust.addressId = addr.addressId " +
            "LEFT JOIN city as ci ON ci.cityId = addr.cityId " +
            "LEFT JOIN country as co ON co.countryId = ci.countryId";

        MySqlCommand cmd = new MySqlCommand(query);
        return cmd;
    }

    public static MySqlCommand GetMaxId()
    {
        //implementation
        MySqlCommand cmd = new MySqlCommand();
        return cmd;
    }
}