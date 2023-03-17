using System.ComponentModel.DataAnnotations;

namespace doanthi.Models
{
    public class Sanpham
    {
        [Key]
        public int Sanpham_id { get; set; }
        public string NameSP { get; set; }
        public string Price { get; set; }

        [DataType(DataType.Date)]
        public string NgayNhap { get; set; }
        public string HSD { get; set; }
        public string image { get; set; }

        public string description   { get; set; }

        public ICollection<Hoadon_Tinh> Hoadon_Tinh { get; set; }
    }
}
