using System;
using System.Threading.Tasks;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class RemoveCommand : BaseCommand, ICommand
    {
        private readonly RemoveOption _options;
        public RemoveCommand(IPeopleRepository peopleRepository, IView view, RemoveOption options) : base(peopleRepository, view)
        {
            _options = options;
        }

        public async Task Execute()
        {
            var person = await PeopleRepository.FindByUserName(_options.UserName);
            if (person == null)
            {
                View.ShowMessage("Person not found.");
                return;
            }

            await RemovePerson(_options.UserName);
        }

        protected virtual async Task RemovePerson(string userName)
        {
            await PeopleRepository.RemovePerson(_options.UserName);
            await PeopleRepository.SaveChanges();

            var removedPerson = await PeopleRepository.FindByUserName(_options.UserName);
            if (removedPerson == null)
                View.ShowMessage("Person removed.");
        }
    }
}