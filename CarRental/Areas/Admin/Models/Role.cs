

namespace CarRental.Areas.Admin.Models
{
    public class Role
    {
        public int Id { get; set; } 
        public string NameRole { get; set; }

        public ICollection<User> Users { get; set; }
       

    }
}
