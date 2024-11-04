using System.ComponentModel;

namespace C969_ScheduleTracker;

public class CustomerManager
{
    private BindingList<Customer> _allCustomers = new BindingList<Customer>();

    public void AddCustomer(Customer customer)
    {
        //implementation
        _allCustomers.Add(customer);
    }

    public void RemoveCustomer(Customer customer)
    {
        //implementation
        _allCustomers.Remove(customer);
    }

    public Customer GetCustomer(int customerId)
    {
        //implementation
        return _allCustomers[customerId];
    }

}