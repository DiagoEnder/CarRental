namespace CarRental.Areas.Admin.Models
{
    public class TinhNang
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<XeTinhNang> XeTinhNang { get ; set; }
        
    }
}
