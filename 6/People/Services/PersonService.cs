using People.Interfaces;
using People.ViewModels.Person;

namespace People.Services
{
    public class PersonService : IPersonService
    {
        public List<PersonForListVM> GetPeopleForList()
        {
            throw new NotImplementedException();
        }

        private readonly IPersonRepository _personRepo;
    }
}
