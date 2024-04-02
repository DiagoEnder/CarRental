using System.ComponentModel.DataAnnotations;
namespace CarRental.Areas.Admin.Models
{
    public class Hang
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Name { get; set; }

        public ICollection<InfoXe> InfoXe { get; set; }
        public ICollection<Loaixe> Loaixe { get; set;}
    }
}
