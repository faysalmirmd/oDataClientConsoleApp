using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public abstract class BaseCommand
    {
        protected readonly IPeopleRepository PeopleRepository;
        protected readonly IView View;

        protected BaseCommand(IPeopleRepository peopleRepository, IView view)
        {
            PeopleRepository = peopleRepository;
            View = view;
        }
    }
}