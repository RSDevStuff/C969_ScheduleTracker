namespace C969_ScheduleTracker;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; } 
public Customer(){}    

public Customer(int customerId, string customerName, string customerAddress, string customerCity, string customerCountry, string customerPhone)
    {
        CustomerId = customerId;
        Name = customerName;
        Address = customerAddress;
        City = customerCity;
        Country = customerCountry;
        Phone = customerPhone;
    }
}