using System.ComponentModel.DataAnnotations;

namespace WebHocTap.Models
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        public string TenUser { get; set; }
        public string HoTen { get; set; }
        public string MatKhau { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public Permission Permission { get; set; }
    }
}
