using People.Interfaces;
using People.ViewModels.Person;

namespace People.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;

        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public ListPersonForListVM GetPeopleForList()
        {
            var people = _personRepo.GetAllActivePeople();
            ListPersonForListVM result = new
            ListPersonForListVM();
            result.People = new List<PersonForListVM>();
            foreach (var person in people)
            {
                // mapowanie obiektow
                var pVM = new PersonForListVM()
                {
                    Id = person.Id,
                    FullName = person.FirstName + " " +
                person.LastName
                };
                result.People.Add(pVM);
            }
            result.Count = result.People.Count;

            return result;
        }
    }
}
