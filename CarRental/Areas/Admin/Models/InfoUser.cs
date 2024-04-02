using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Areas.Admin.Models
{
    public class InfoUser
    {
        public int Id { get; set; }
        
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string CCCD { get; set; }
        public string GPLX { get; set; }

        [Required(ErrorMessage = "Please choose Front Images")]
        [Display(Name = "ImgGplx")]
        [NotMapped]
        public IFormFile FrontImage2 { get; set; }

        public string ImgGplx { get; set; }

        [Required(ErrorMessage = "Please choose Front Images")]
        [Display(Name = "ImgUser")]
        [NotMapped]
        public IFormFile FrontImage { get; set; }
        public string? Img { get; set; }

        public DateTime Ngaysinh { get; set; }
        public int GioiTinh { get; set; }

        
        public ICollection<HoaDon> HoaDoncs { get; set;}
        public ICollection<SanPham> sanPhams { get; set; }
        public ICollection<Feedback> FeedbacksCus { get; set; }
        public ICollection<Feedback> FeedbacksOwner { get; set; }

        public ICollection<DonDatXe> DonDatXesCus { get; set; }
        public ICollection<DonDatXe> DonDatXesOwner { get; set; }
    }
}
