using System.ComponentModel.DataAnnotations;

namespace CarRental.Areas.Admin.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User Password is Required")]

        public string Password { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is Required")]

        public string Phone { get; set; }
        public int IdRole { get; set; }

        public Role role { get; set; }
        public ICollection<InfoXe> InfoXe { get; set; }
    }
}
