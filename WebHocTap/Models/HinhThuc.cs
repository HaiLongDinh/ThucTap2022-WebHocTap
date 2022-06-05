using System.ComponentModel.DataAnnotations;

namespace WebHocTap.Models
{
    public class HinhThuc
    {
        [Key]
        public Guid ID { get; set; }
        public string TenHinhThuc { get; set; }
    }
}
