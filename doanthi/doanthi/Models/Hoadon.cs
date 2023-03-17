using System.ComponentModel.DataAnnotations;

namespace doanthi.Models
{
    public class Hoadon
    {
        [Key]
        public int Hoadon_id { get; set; }
        public string TenHD { get; set; }

        [DataType(DataType.Date)]
        public string NgaylapHD { get; set; }
        public int User_id { get; set; }
        public User User { get; set; }

        public ICollection<Hoadon_Tinh> Hoadon_Tinh { get; set; }


    }
}
