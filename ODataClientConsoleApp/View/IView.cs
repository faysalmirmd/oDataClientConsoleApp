using Microsoft.OData.SampleService.Models.TripPin;
using System.Collections.Generic;

namespace ODataClientConsoleApp.View
{
    public interface IView
    {
        void ShowPeople(IEnumerable<Person> people);
        void ShowPerson(Person person);
        void ShowPersonDetails(Person person);
        void ShowMessage(string message);
        void ShowLoading();
        void HideLoading();
    }
}
