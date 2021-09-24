using Microsoft.OData.SampleService.Models.TripPin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ODataClientConsoleApp.View
{
    public class ConsoleView: IView
    {
        public void ShowPeople(List<Person> people)
        {
            foreach (var person in people)
            {
                ShowPerson(person);
            }
        }

        public void ShowPerson(Person person)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName} ({person.UserName})");
        }

        public void ShowPersonDetails(Person person)
        {
            Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
            Console.WriteLine($"UserName: {person.UserName}");
            Console.WriteLine($"Gender: {person.Gender}");
            Console.WriteLine($"Photo: {person.Photo?.Name}");
            var emails = string.Join(", ", person.Emails); 
            Console.WriteLine($"Emails: {emails}");
            PrintAddress(person.AddressInfo);
        }

        private void PrintAddress(ObservableCollection<Location> personAddressInfo)
        {
            Console.WriteLine("Addresses:");

            foreach (var location in personAddressInfo)
            {
                Console.WriteLine($"  Address: {location.Address}");
                Console.WriteLine($"  City: {location.City.Name}");
                Console.WriteLine($"  Region: {location.City.Region}");
                Console.WriteLine($"  Country Region: {location.City.CountryRegion}");
                Console.WriteLine();
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowLoading()
        {
            Console.Write("Loading...");
        }

        public void HideLoading()
        {
            Console.Write("\b\b\b\b\b\b\b\b\b\b");
        }
    }
}
