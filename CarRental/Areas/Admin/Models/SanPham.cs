using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Areas.Admin.Models
{
    public class SanPham
    {

       public int Id { get; set; }
       //public string NameXe { get; set; }
        public int IdInfo { get; set; }
        public int IdChuXe { get; set; }
        public string? Loinhan { get; set; }
        public string Diachixe { get; set; }

        public int LimitXechay { get; set; }
        public double GiaVuot { get; set; }

        [Required(ErrorMessage = "Please choose Front Images")]
        [Display(Name = "ImgUser")]
        [NotMapped]
        public IFormFile FrontImage { get; set; }
        public string Img { get; set; }
       
        public int GioiHankmgiaoxe { get; set; }
        public double Gia { get; set; }
        public int State { get; set; }

       
        public InfoXe InfoXe { get; set; }
        public InfoUser InfoUser { get; set; }
        public ICollection<DonDatXe> DonDatXes { get; set; }
        public ICollection<CTHD> CTHDs { get; set; }

    }
}
