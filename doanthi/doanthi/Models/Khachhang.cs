using System.ComponentModel.DataAnnotations;

namespace doanthi.Models
{
    public class Khachhang
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birday  { get; set; }

    }
}
