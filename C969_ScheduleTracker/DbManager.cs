using System.ComponentModel;
using MySql.Data.MySqlClient;
using Mysqlx.Resultset;
using Org.BouncyCastle.Asn1.Mozilla;

namespace C969_ScheduleTracker;

public static class DbManager
{
    private static readonly string ConnectionString =
        "server=localhost;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!";

    //Custom object implementation
    //Requires an empty constructor for each custom object
    public static BindingList<T> ExecuteQueryToBindingList<T>(MySqlCommand cmd) where T : new()
    {
        var resultList = new BindingList<T>();
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            try
            {
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
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }

            return resultList;
        }
    }

    public static int ExecuteModification(MySqlCommand cmd)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            try
            {
                connection.Open();
                cmd.Connection = connection;
                using (cmd)
                {
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show($"Error: {e.Message}");
                return -1;
            }
        }
    }

    public static int ExecuteModificationReturnId(MySqlCommand cmd)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            //try
            //{
                connection.Open();
                cmd.Connection = connection;
                using (cmd)
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            //}
            //catch (MySqlException e)
            //{
            //    MessageBox.Show($"Error: {e.Message}");
            //    return -1;
            //}
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
                       "app.customerId as CustomerId," +
                       "app.appointmentId as AppointmentId " +
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

    public static MySqlCommand GetAddressAll()
    {
        string query = "select addressId as AddressId," +
                       "address as AddressName, " +
                       "city.cityId as CityId, " +
                       "city.city as City, " +
                       "country.countryId as CountryId," +
                       "country.country as Country FROM address " +
                       "LEFT JOIN city on city.cityId = address.cityId " +
                       "LEFT JOIN country on country.countryId = city.countryId";

        MySqlCommand cmd = new MySqlCommand(query);
        return cmd;
    }

    public static MySqlCommand InsertNewAppointmentCommand(int custId, int userId, string type, DateTime start, DateTime end, string userName)
    {
        string notNeeded = "not needed";
        DateTime currentDate = DateTime.Now;
        string insertStatement =
            "INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)VALUES" +
            "(@customerId,@userId, @notNeeded, @notNeeded, @notNeeded, @notNeeded, @type, @notNeeded, @startTime,@endTime,@createDate,@userName,@createDate,@userName)";
        MySqlCommand cmd = new MySqlCommand(insertStatement);
        cmd.Parameters.AddWithValue("@customerId", custId);
        cmd.Parameters.AddWithValue("@userId", userId);
        cmd.Parameters.AddWithValue("@notNeeded", notNeeded);
        cmd.Parameters.AddWithValue("@type", type);
        cmd.Parameters.AddWithValue("@startTime", start);
        cmd.Parameters.AddWithValue("@endTime", end);
        cmd.Parameters.AddWithValue("@userName", userName);
        cmd.Parameters.AddWithValue("@createDate", currentDate);
        return cmd;
    }

    public static MySqlCommand RemoveExistingAppointment(string appointmentId)
    {
        string removeStatement =
            "DELETE FROM appointment WHERE appointmentId = @appointmentId";
        MySqlCommand cmd = new MySqlCommand(removeStatement);
        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
        return cmd;
    }

    public static MySqlCommand ModifyExistingAppointment(int custId, string type, DateTime start, DateTime end, string userName, string appointmentId)
    {
        DateTime currentDate = DateTime.Now.ToUniversalTime();
        string updateStatement =
            "UPDATE appointment SET " +
            "customerId = @customerId, " +
            "type = @type, " +
            "start = @start, " +
            "end = @end, " +
            "lastUpdate = @currentDate, " +
            "lastUpdateBy = @currentUser " +
            "WHERE appointmentId = @appointmentId";

        MySqlCommand cmd = new MySqlCommand(updateStatement);
        cmd.Parameters.AddWithValue("@customerId", custId);
        cmd.Parameters.AddWithValue("@type", type);
        cmd.Parameters.AddWithValue("@start", start.ToUniversalTime());
        cmd.Parameters.AddWithValue("@end", end.ToUniversalTime());
        cmd.Parameters.AddWithValue("@currentDate", currentDate.ToUniversalTime());
        cmd.Parameters.AddWithValue("@currentUser", userName);
        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
        return cmd;
    }

    public static MySqlCommand AddNewCustomer(string customerName, int addressId, string userName)
    {
    
        DateTime currentDate = DateTime.Now.ToUniversalTime();
        string insertStatement = 
            "INSERT INTO customer(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES" +
                                 "(@customerName,@addressId, 1, @currentDate, @userName, @currentDate, @userName); SELECT LAST_INSERT_ID();";
        MySqlCommand cmd = new MySqlCommand(insertStatement);
        cmd.Parameters.AddWithValue("@customerName", customerName);
        cmd.Parameters.AddWithValue("@addressId", addressId);
        cmd.Parameters.AddWithValue("@currentDate", currentDate);
        cmd.Parameters.AddWithValue("@userName", userName);
        return cmd;
    }

    public static MySqlCommand AddNewCountry(string countryName, string userName)
    {
        DateTime currentDate = DateTime.Now.ToUniversalTime();
        string insertStatement =
            "INSERT INTO country(country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
            "VALUES(@countryName, @currentDate, @userName, @currentDate, @userName); " +
            "SELECT LAST_INSERT_ID();";
        MySqlCommand cmd = new MySqlCommand(insertStatement);
        cmd.Parameters.AddWithValue("@countryName", countryName);
        cmd.Parameters.AddWithValue("@currentDate", currentDate);
        cmd.Parameters.AddWithValue("@userName", userName);
        return cmd;
    }

    public static MySqlCommand AddNewCity(string cityName, int countryId, string userName)
    {
        DateTime currentDate = DateTime.Now.ToUniversalTime();
        string insertStatement =
            "INSERT INTO city(city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
            "VALUES(@cityName, @countryId, @currentDate, @userName, @currentDate, @userName); " +
            "SELECT LAST_INSERT_ID();";
        MySqlCommand cmd = new MySqlCommand(insertStatement);
        cmd.Parameters.AddWithValue("@cityName", cityName);
        cmd.Parameters.AddWithValue("@countryId", countryId);
        cmd.Parameters.AddWithValue("@currentDate", currentDate);
        cmd.Parameters.AddWithValue("@userName", userName);
        return cmd;
    }

    public static MySqlCommand AddNewAddress(string addressName, int cityId, string phone, string userName)
    {
        DateTime currentDate = DateTime.Now.ToUniversalTime();

        string insertStatement =
            "INSERT INTO address(address, address2, cityId, postalCode, phone, createDate, " +
            "createdBy, lastUpdate, lastUpdateBy) " +
            "VALUES(@addressName, ' ', @cityId, ' ', @phone, @currentDate, @userName, @currentDate, @userName); " +
            "SELECT LAST_INSERT_ID();";
        MySqlCommand cmd = new MySqlCommand(insertStatement);
        cmd.Parameters.AddWithValue("@addressName", addressName);
        cmd.Parameters.AddWithValue("@cityId", cityId);
        cmd.Parameters.AddWithValue("@phone", phone);
        cmd.Parameters.AddWithValue("@currentDate", currentDate);
        cmd.Parameters.AddWithValue("@userName", userName);
        return cmd;
    }
    public static MySqlCommand RemoveExistingCustomer(string customerId)
    {
        string removeStatement =
            "DELETE FROM appointment WHERE customerId = @customerId; " +
            "DELETE FROM customer WHERE customerId = @customerId;";
        MySqlCommand cmd = new MySqlCommand(removeStatement);
        cmd.Parameters.AddWithValue("@customerId", customerId);
        return cmd;
    }

}