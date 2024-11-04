namespace C969_ScheduleTracker;

public class Customer
{
    public int CustomerId {get; set; }
    public string CustomerName {get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerCountry { get; set; }
    public string CustomerPhone { get; set; }

    public Customer(int customerId, string customerName, string customerAddress, string customerCity, string customerCountry, string customerPhone)
    {
        CustomerId = customerId;
        CustomerName = customerName;
        CustomerAddress = customerAddress;
        CustomerCity = customerCity;
        CustomerCountry = customerCountry;
        CustomerPhone = customerPhone;
    }
}