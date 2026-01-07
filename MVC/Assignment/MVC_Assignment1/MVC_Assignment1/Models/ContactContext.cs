using System.Data.Entity;

namespace MVC_Assignment1.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("ContactDBConnection")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}