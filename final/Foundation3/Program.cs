using System;

class Program
{
    static void Main()
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "CityA", "StateA", "CountryA");
        Address address2 = new Address("456 Elm St", "CityB", "StateB", "CountryB");
        Address address3 = new Address("789 Oak St", "CityC", "StateC", "CountryC");

        // Create events
        Event lectureEvent = new Lecture("Lecture Title", "Description for Lecture", new DateTime(2023, 12, 15, 10, 30, 0), address1, "SpeakerA", 100);

        Event receptionEvent = new Reception("Reception Title", "Description for Reception", new DateTime(2023, 12, 16, 18, 0, 0), address2, "rsvp@example.com");

        Event outdoorEvent = new OutdoorGathering("Outdoor Gathering Title", "Description for Outdoor Gathering", new DateTime(2023, 12, 17, 14, 0, 0), address3, "Sunny");

        // Display marketing messages for each event
        DisplayMarketingMessages(lectureEvent);
        DisplayMarketingMessages(receptionEvent);
        DisplayMarketingMessages(outdoorEvent);
    }

    static void DisplayMarketingMessages(Event ev)
    {
        Console.WriteLine("Standard Details:");
        Console.WriteLine(ev.GetStandardDetails());

        Console.WriteLine("\nFull Details:");
        Console.WriteLine(ev.GetFullDetails());

        Console.WriteLine("\nShort Description:");
        Console.WriteLine(ev.GetShortDescription());

        Console.WriteLine();
    }
}

class Event
{
    private string title;
    private string description;
    private DateTime dateTime;
    private Address address;

    public Event(string title, string description, DateTime dateTime, Address address)
    {
        this.title = title;
        this.description = description;
        this.dateTime = dateTime;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {dateTime.ToShortDateString()}\nTime: {dateTime.ToShortTimeString()}\nAddress: {address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: Generic Event\nTitle: {title}\nDate: {dateTime.ToShortDateString()}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime dateTime, Address address, string speaker, int capacity)
        : base(title, description, dateTime, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime dateTime, Address address, string rsvpEmail)
        : base(title, description, dateTime, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weather;

    public OutdoorGathering(string title, string description, DateTime dateTime, Address address, string weather)
        : base(title, description, dateTime, address)
    {
        this.weather = weather;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Outdoor Gathering\nWeather: {weather}";
    }
}

class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}, {city}, {stateProvince}, {country}";
    }
}

