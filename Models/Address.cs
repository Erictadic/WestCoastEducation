namespace WCEapp.Models;

public class Address
{
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }


    public Address(string street, string postalcode, string city)
    {
        Street = street;
        PostalCode = postalcode;
        City = city;
    }
}