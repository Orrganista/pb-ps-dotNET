using EFDemo.Models;
using Microsoft.EntityFrameworkCore;


public class PeopleContext : DbContext
{
    public DbSet<Person> Person { get; set; }
}