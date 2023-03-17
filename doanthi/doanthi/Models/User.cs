using System.ComponentModel.DataAnnotations;

namespace doanthi.Models
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phanquyen { get; set; }
        public ICollection<Hoadon> Hoadon { get; set; }

    }
}
