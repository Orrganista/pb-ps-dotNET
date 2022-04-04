namespace People.ViewModels.Person
{
    public class PersonForListVM
    {
        public int Id { get; set; }
        public string? FullName { get; set; }

    }

    public class ListPersonForListVM
    {
        public List<PersonForListVM>? People { get; set; }
        public int Count { get; set; }
    }
}
