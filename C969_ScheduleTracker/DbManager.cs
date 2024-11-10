using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Resultset;
using Org.BouncyCastle.Asn1.Mozilla;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace C969_ScheduleTracker;

public static class DbManager
{
    private static readonly string ConnectionString =
        "server=localhost;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!";

    //Custom object implementation, rewritten to allow ad hoc objects and returns them as DataTables
    //Requires an empty constructor for each custom object
    public static object ExecuteQuery(MySqlCommand cmd, Type type = null)
    {
        // If a specific type is provided, create a BindingList of that type, similar to ExecuteQueryToBindingList.
        if (type != null)
        {
            var bindingListType = typeof(BindingList<>).MakeGenericType(type);
            var resultList = (IBindingList)Activator.CreateInstance(bindingListType);

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    cmd.Connection = connection;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        var properties = type.GetProperties();
                        while (reader.Read())
                        {
                            var item = Activator.CreateInstance(type);
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
            }

            return resultList;
        }
        else
        {
            // Fall back to DataTable for ad hoc queries without a class structure
            var resultList = new List<Dictionary<string, object>>();
            DataTable table = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    cmd.Connection = connection;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            table.Columns.Add(reader.GetName(i), typeof(object));
                        }

                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var columnName = reader.GetName(i);
                                // Lambda to determine if a column is null, if it is assign it so, else get the value.
                                var columnValue = reader.IsDBNull(i) ? DBNull.Value : reader.GetValue(i);
                                row[columnName] = columnValue;
                            }
                            resultList.Add(row);

                            // Populate DataTable row 
                            var dataRow = table.NewRow();
                            foreach (var kvp in row)
                            {
                                dataRow[kvp.Key] = kvp.Value;
                            }
                            table.Rows.Add(dataRow);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"Error: {e.Message}");
                }
            }

            return table;
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
                       "phone as Phone, " +
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

    public static MySqlCommand UpdateExistingAddress(int addressId, string addressName, int cityId, string phone, string userName)
    {
        DateTime currentDate = DateTime.Now.ToUniversalTime();
        string updateStatement =
            "UPDATE address " +
            "SET address = @addressName, " +
            "cityId = @cityId, " +
            "phone = @phone, " +
            "lastUpdate = @currentDate, " +
            "lastUpdateBy = @currentUser " +
            "WHERE addressId = @addressId;";
        MySqlCommand cmd = new MySqlCommand(updateStatement);
        cmd.Parameters.AddWithValue("@addressName", addressName);
        cmd.Parameters.AddWithValue("@cityId", cityId);
        cmd.Parameters.AddWithValue("@phone", phone);
        cmd.Parameters.AddWithValue("@currentDate", currentDate);
        cmd.Parameters.AddWithValue("@currentUser", userName);
        cmd.Parameters.AddWithValue("@addressId", addressId);
        return cmd;
    }

    public static MySqlCommand UpdateExistingCustomer(string customerId, string customerName, int addressId, string userName)
    {
        DateTime currentDate = DateTime.Now.ToUniversalTime();
        string updateStatement =
            "UPDATE customer " +
            "SET addressId = @addressId, " +
            "customerName = @customerName, " +
            "lastUpdate = @currentDate, " +
            "lastUpdateBy = @currentUser " +
            "WHERE customerId = @customerId;";
        MySqlCommand cmd = new MySqlCommand(updateStatement);
        cmd.Parameters.AddWithValue("@addressId", addressId);
        cmd.Parameters.AddWithValue("@customerId", customerId);
        cmd.Parameters.AddWithValue("@customerName", customerName);
        cmd.Parameters.AddWithValue("@currentDate", currentDate);
        cmd.Parameters.AddWithValue("@currentUser", userName);
        return cmd;
    }

    public static MySqlCommand GrabAllUsers()
    {
        string query = "SELECT userId as UserId, userName as Username, password as Password FROM user";
        MySqlCommand cmd = new MySqlCommand(query);
        return cmd;
    }

    public static MySqlCommand GetTypeCounts(DateTime start, DateTime end)
    {
        string query = "SELECT type as Type, COUNT(type) as Count FROM appointment " +
                       "WHERE (start BETWEEN @startDate AND @endDate) " +
                       "GROUP BY type";
        MySqlCommand cmd = new MySqlCommand(query);
        cmd.Parameters.AddWithValue("@startDate", start);
        cmd.Parameters.AddWithValue("@endDate", end);
        return cmd;
    }
}