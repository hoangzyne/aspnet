using System.ComponentModel.DataAnnotations;

namespace doanthi.Models
{
    public class Hoadon_Tinh
    {
        [Key]
        public int Id { get; set; }

        public string Quality { get; set; }

        public int Hoadon_id  { get; set; }
        public Hoadon Hoadon { get; set; }
        public int Sanpham_id { get; set; }
        public Sanpham Sanpham { get; set; }


    }
}
