using People.ViewModels.Person;

namespace People.Interfaces
{
    public interface IPersonService
    {
        List<PersonForListVM> GetPeopleForList();
    }
}
