namespace C969_ScheduleTracker;

public class FullAddress
{
    public int AddressId { get; set; }
    public string AddressName { get; set; }
    public int CityId { get; set; }
    public string City { get; set; }
    public int CountryId { get; set; }
    public string Country { get; set; }

    public FullAddress() { }

    public FullAddress(int addressId, string addressName, int cityId, string city, int countryId, string country)
    {
        AddressId = addressId;
        AddressName = addressName;
        CityId = cityId;
        City = city;
        CountryId = countryId;
        Country = country;
    }
}