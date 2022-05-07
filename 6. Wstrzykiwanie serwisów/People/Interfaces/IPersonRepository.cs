using People.Models;

namespace People.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetAllActivePeople();
    }
}
