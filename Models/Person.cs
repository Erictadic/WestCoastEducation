using WCEapp.Interfaces;

namespace WCEapp.Models;

public abstract class Person : IPresentable
{
    public string FirstName { get; set; }
    public string LastName {get; set;}
    public string PhoneNumber {get; set;}
    public string PersonalNumber {get; set;}
    public Address Address { get; set; }

    public Person(string firstName, string lastName, string phoneNumber, string personalNumber, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        PersonalNumber = personalNumber;
        Address = address;
    }
    public virtual string Role => "Person";
    public virtual string Present()
    {
        return $"{Role}: {FirstName} {LastName} {PhoneNumber}";
    }
}