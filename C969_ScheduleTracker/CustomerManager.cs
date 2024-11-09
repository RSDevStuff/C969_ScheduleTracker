using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel;

namespace C969_ScheduleTracker;

public static class CustomerManager
{
    private static BindingList<Customer> _allCustomers = new BindingList<Customer>();
    public static BindingList<Customer> AllCustomers => _allCustomers;

    private static BindingList<FullAddress> _allAddresses = new BindingList<FullAddress>();
    public static BindingList<FullAddress> AllAddresses => _allAddresses; 

    public static void LoadCustomersFromDb(BindingList<Customer> customers)
    {
        _allCustomers.Clear();
        foreach (var customer in customers)
        {
            _allCustomers.Add(customer);
        }
    }

    public static void LoadAddressesFromDb(BindingList<FullAddress> addresses)
    {
        _allAddresses.Clear();
        foreach (var address in addresses)
        {
            _allAddresses.Add(address);
        }
    }

    public static void AddCustomer(Customer customer)
    {
        //implementation
        _allCustomers.Add(customer);
    }

    public static void RemoveCustomer(Customer customer)
    {
        //implementation
        _allCustomers.Remove(customer);
    }

    public static BindingList<Customer> GetCustomerById(int customerId)
    {
        //implementation
        return new BindingList<Customer>(_allCustomers.Where(customer => customer.CustomerId == customerId).ToList());
    }



}